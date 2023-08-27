using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;

namespace MoviesTest.Web.Api.BusinessLayer.Interfaces;

public interface IReservationBusinessService: IBusinessRepository<ReservationModel, long>, IBusinessRepositoryAggregated<ReservationModel, long>
{
    Task<ReservationModel> GetRecordByApprovalKey(Guid approvalKey);
    Task ApproveReservation(Guid approvalKey);
    Task ExpireReservations();
    
    
}