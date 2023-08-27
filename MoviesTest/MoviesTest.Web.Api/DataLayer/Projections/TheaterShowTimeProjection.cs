using System.Collections.Immutable;

namespace MoviesTest.Web.Api.DataLayer.Projections;

public class TheaterShowTimeProjection
{
    public long Id { get; set; }
    public long TheaterId { get; set; }
    public long MovieId { get; set; }
    public DateTimeOffset StartDateTimeUtc { get; set; }
    public DateTimeOffset EndDateTimeUtc { get; set; }
    public float TicketPriceUsd { get; set; }
}