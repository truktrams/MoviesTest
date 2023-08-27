using MoviesTest.Sdk.Constants;
using MoviesTest.Sdk.Exceptions;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.BusinessLayer.Translators;
using MoviesTest.Web.Api.DataLayer.Interfaces;

namespace MoviesTest.Web.Api.BusinessLayer.Services;

public class ReservationBusinessService : IReservationBusinessService
{
    private readonly IReservationDataService _svcReservation;
    private readonly ITheaterSeatReservationBusinessService _svcTheaterSeatReservation;

    public ReservationBusinessService(IReservationDataService svcReservation, ITheaterSeatReservationBusinessService svcTheaterSeatReservation)
    {
        _svcReservation = svcReservation;
        _svcTheaterSeatReservation = svcTheaterSeatReservation;
    }

    #region 'BusinessRepository'

    public async Task<IEnumerable<ReservationModel>> GetRecords()
    {
        return (await _svcReservation.GetRecords()).Select(ReservationTranslator.ToBusinessModel);
    }

    public async Task<ReservationModel> GetRecord(long id)
    {
        return ReservationTranslator.ToBusinessModel(await _svcReservation.GetRecord(id));
    }

    public async Task<long> CreateRecord(ReservationModel model)
    {
        model.ReservationStateCode = ReservationStates.PendingApproval;
        model.ApprovalKey = Guid.NewGuid();
        model.Validate();
        return await _svcReservation.CreateRecord(ReservationTranslator.ToProjection(model));
    }

    public Task UpdateRecord(ReservationModel model)
    {
        model.Validate();
        return _svcReservation.UpdateRecord(ReservationTranslator.ToProjection(model));
    }

    public Task DeleteRecord(long id)
    {
        return _svcReservation.DeleteRecord(id);
    }

    #endregion

    #region 'BusinessRepositoryAggregated'

    public async Task<IEnumerable<ReservationModel>> GetRecordsAggregated()
    {
        var result = (await _svcReservation.GetRecords()).Select(ReservationTranslator.ToBusinessModel).ToArray();
        for (int i = 0; i < result.Count(); i++)
            result[i].TheaterSeatReservations = (await _svcTheaterSeatReservation.GetRecordsForReservation(result[i].Id));
        return result;
    }

    public async Task<ReservationModel> GetRecordAggregated(long id)
    {
        var result = ReservationTranslator.ToBusinessModel(await _svcReservation.GetRecord(id));
        result.TheaterSeatReservations = await _svcTheaterSeatReservation.GetRecordsForReservation(result.Id);
        return result;
    }

    public async Task<long> CreateRecordAggregated(ReservationModel model)
    {
        if (!await _svcTheaterSeatReservation.CheckTheaterSeatsReservationAvailability(
                model.TheaterShowTimeId,
                model.TheaterSeatReservations.Select(x => x.TheaterSeatId).ToArray()))
            throw new MoviesTestException("Can not create reservation. Some seats are occupied.");

        model.ApprovalKey = Guid.NewGuid();
        model.ReservationStateCode = ReservationStates.PendingApproval;
        model.Validate();
        var id = await _svcReservation.CreateRecord(ReservationTranslator.ToProjection(model));
        foreach (var k in model.TheaterSeatReservations)
        {
            k.ReservationId = id;
            k.TheaterShowTimeId = model.TheaterShowTimeId;
            await _svcTheaterSeatReservation.CreateRecord(k);
        }

        return id;
    }

    public async Task UpdateRecordAggregated(ReservationModel model)
    {
        model.Validate();
        await _svcReservation.UpdateRecord(ReservationTranslator.ToProjection(model));
        foreach (var k in model.TheaterSeatReservations)
        {
            k.ReservationId = model.Id;
            if (k.ReservationId < 1)
                await _svcTheaterSeatReservation.CreateRecord(k);
            else
                await _svcTheaterSeatReservation.UpdateRecord(k);
        }
    }

    public async Task DeleteRecordAggregated(long key)
    {
        var model = await GetRecordAggregated(key);
        await DeleteRecord(model.Id);
        foreach (var k in model.TheaterSeatReservations)
            await _svcTheaterSeatReservation.DeleteRecord(k.Id);
    }

    #endregion

    public async Task<ReservationModel> GetRecordByApprovalKey(Guid approvalKey)
    {
        return ReservationTranslator.ToBusinessModel(await _svcReservation.GetRecordByApprovalKey(approvalKey));
    }

    public async Task ApproveReservation(Guid approvalKey)
    {
        var model = await GetRecordByApprovalKey(approvalKey);
        model.ReservationStateCode = ReservationStates.Approved;
        await UpdateRecord(model);
    }

    public async Task ExpireReservations()
    {
        var expirationThreshold = DateTimeOffset.FromUnixTimeMilliseconds(
            DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - (long)TimeSpan.FromMinutes(SystemConfiguration.ReservationConfirmationTimeoutInMinutes).TotalMilliseconds);
        var recordsToExpire = (await _svcReservation.GetRecordsToExpire(expirationThreshold)).Select(ReservationTranslator.ToBusinessModel);
        foreach (var k in recordsToExpire)
        {
            k.ReservationStateCode = ReservationStates.Expired;
            await UpdateRecord(k);
        }
    }
}