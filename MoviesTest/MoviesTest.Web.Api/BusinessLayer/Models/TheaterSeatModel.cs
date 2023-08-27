using FluentAssertions;

namespace MoviesTest.Web.Api.BusinessLayer.Models;

public class TheaterSeatModel
{
    public long Id { get; set; }
    public long TheaterId { get; set; }
    public string Title { get; set; }
    public float SeatPrice { get; set; }

    public void Validate()
    {
        this.TheaterId.Should().BeGreaterThan(0,  "TheaterId should be specified.");
        this.Title.Should().NotBeNullOrWhiteSpace("Title can not be null.");
        this.SeatPrice.Should().BePositive( "SeatPrice should be positive.");
    }
}