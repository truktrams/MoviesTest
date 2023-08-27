using System.Collections.Immutable;

namespace MoviesTest.Web.Api.DataLayer.Projections;

public class TheaterSeatReservationProjection
{
    public long Id { get; set; }
    public long TheaterSeatId { get; set; }
    public long ReservationId { get; set; }
    public long TheaterShowTimeId { get; set; }
}