using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.DataLayer.Projections;

namespace MoviesTest.Web.Api.DataLayer.Interfaces;

public interface IReservationDataService: IDataRepository<ReservationProjection, long>
{
    Task<ReservationProjection> GetRecordByApprovalKey(Guid approvalKey);
    Task<IEnumerable<ReservationProjection>> GetRecordsToExpire(DateTimeOffset expirationThreshold);
}