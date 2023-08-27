using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;

namespace MoviesTest.Web.Api.BusinessLayer.Interfaces;

public interface ITheaterSeatReservationBusinessService: IBusinessRepository<TheaterSeatReservationModel, long>
{
    Task<IEnumerable<TheaterSeatReservationModel>> GetRecordsForReservation(long reservationId);
    Task<bool> CheckTheaterSeatsReservationAvailability (long showTimeId, long[] seatIds);
}