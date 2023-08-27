using MoviesTest.Sdk.Exceptions;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.BusinessLayer.Translators;
using MoviesTest.Web.Api.DataLayer.Interfaces;

namespace MoviesTest.Web.Api.BusinessLayer.Services;

public class TheaterSeatReservationBusinessService : ITheaterSeatReservationBusinessService
{
    private readonly ITheaterSeatReservationDataService _svcTheaterSeatReservation;

    public TheaterSeatReservationBusinessService(ITheaterSeatReservationDataService svcTheaterSeatReservation)
    {
        _svcTheaterSeatReservation = svcTheaterSeatReservation;
    }

    #region 'BusinessRepository'

    public async Task<IEnumerable<TheaterSeatReservationModel>> GetRecords()
    {
        return (await _svcTheaterSeatReservation.GetRecords()).Select(TheaterSeatReservationTranslator.ToBusinessModel);
    }

    public async Task<TheaterSeatReservationModel> GetRecord(long id)
    {
        return TheaterSeatReservationTranslator.ToBusinessModel(await _svcTheaterSeatReservation.GetRecord(id));
    }

    public async Task<long> CreateRecord(TheaterSeatReservationModel model)
    {
        model.Validate();
        if (!await _svcTheaterSeatReservation.CheckTheaterSeatsReservationAvailability(
                model.TheaterShowTimeId,
                new long [] { model.TheaterSeatId }))
            throw new MoviesTestException("Can not reserve seat. It is already occupied.");
        return await _svcTheaterSeatReservation.CreateRecord(TheaterSeatReservationTranslator.ToProjection(model));
    }

    public Task UpdateRecord(TheaterSeatReservationModel model)
    {
        model.Validate();
        return _svcTheaterSeatReservation.UpdateRecord(TheaterSeatReservationTranslator.ToProjection(model));
    }

    public Task DeleteRecord(long id)
    {
        return _svcTheaterSeatReservation.DeleteRecord(id);
    }
    
    #endregion

    public async Task<IEnumerable<TheaterSeatReservationModel>> GetRecordsForReservation(long reservationId)
    {
        return (await _svcTheaterSeatReservation.GetRecordsForReservation(reservationId)).Select(TheaterSeatReservationTranslator.ToBusinessModel);
    }

    public async Task<bool> CheckTheaterSeatsReservationAvailability(long showTimeId, long[] seatIds)
    {
        return await _svcTheaterSeatReservation.CheckTheaterSeatsReservationAvailability(showTimeId, seatIds);
    }
}