using FluentAssertions;

namespace MoviesTest.Web.Api.BusinessLayer.Models;

public class TheaterSeatReservationModel
{
    public long Id { get; set; }
    public long TheaterSeatId { get; set; }
    public long ReservationId { get; set; }
    public long TheaterShowTimeId { get; set; }

    public void Validate()
    {
        this.TheaterSeatId.Should().BeGreaterThan(0, "TheaterSeatId should be specified.");
        this.ReservationId.Should().BeGreaterThan(0, "ReservationId should be specified.");
        this.TheaterShowTimeId.Should().BeGreaterThan(0, "TheaterShowTimeId should be specified.");
    }
}