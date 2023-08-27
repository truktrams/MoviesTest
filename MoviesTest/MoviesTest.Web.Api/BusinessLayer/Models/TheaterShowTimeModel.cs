using FluentAssertions;

namespace MoviesTest.Web.Api.BusinessLayer.Models;

public class TheaterShowTimeModel
{
    public long Id { get; set; }
    public long TheaterId { get; set; }
    public long MovieId { get; set; }
    public DateTimeOffset StartDateTimeUtc { get; set; }
    public DateTimeOffset EndDateTimeUtc { get; set; }
    public float TicketPriceUsd { get; set; }

    public void Validate()
    {
        this.TheaterId.Should().BeGreaterThan(0, "TheaterId should be specified.");
        this.MovieId.Should().BeGreaterThan(0, "MovieId should be specified.");
        this.TicketPriceUsd.Should().BePositive("TicketPriceUsd should be positive.");
    }
}