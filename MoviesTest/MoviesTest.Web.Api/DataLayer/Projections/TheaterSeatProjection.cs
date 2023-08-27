using System.Collections.Immutable;

namespace MoviesTest.Web.Api.DataLayer.Projections;

public class TheaterSeatProjection
{
    public long Id { get; set; }
    public long TheaterId { get; set; }
    public string Title { get; set; }
    public float SeatPrice { get; set; }
}