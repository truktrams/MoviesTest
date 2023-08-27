using System.Collections.Immutable;

namespace MoviesTest.Web.Api.DataLayer.Projections;

public class MovieProjection
{
    public long Id { get; set; }
    public string GenreCode { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public float Rating { get; set; }
    public string Description { get; set; }
    public long DurationTicks { get; set; }
}