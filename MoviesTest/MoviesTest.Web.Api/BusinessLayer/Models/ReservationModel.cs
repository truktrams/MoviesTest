using FluentAssertions;

namespace MoviesTest.Web.Api.BusinessLayer.Models;

public class ReservationModel
{
    public long Id { get; set; }
    public string ReservationStateCode { get; set; }
    public long UserId { get; set; }
    public long TheaterId { get; set; }
    public long TheaterShowTimeId { get; set; }
    public DateTimeOffset ReservedAt { get; set; }
    public Guid? ApprovalKey { get; set; }

    public IEnumerable<TheaterSeatReservationModel> TheaterSeatReservations { get; set; }

    public void Validate()
    {
        this.UserId.Should().BeGreaterThan(0,  "UserId should be specified.");
        this.TheaterId.Should().BeGreaterThan(0,  "TheaterId should be specified.");
        this.TheaterShowTimeId.Should().BeGreaterThan(0,  "TheaterShowTimeId should be specified.");
        this.ReservedAt.Should().NotBeAfter(DateTimeOffset.UtcNow, "ReservedAt should not be after current date.");
    }
}