using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.DataLayer.Projections;

namespace MoviesTest.Web.Api.DataLayer.Interfaces;

public interface ITheaterSeatReservationDataService: IDataRepository<TheaterSeatReservationProjection, long>
{
    Task<IEnumerable<TheaterSeatReservationProjection>> GetRecordsForReservation(long reservationId);
    Task<bool> CheckTheaterSeatsReservationAvailability (long showTimeId, long[] seatIds);
}