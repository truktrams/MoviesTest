using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.DataLayer.Projections;

namespace MoviesTest.Web.Api.BusinessLayer.Translators;

public class MovieTranslator
{
    public static MovieModel ToBusinessModel(MovieProjection mdl) => new MovieModel()
    {
        Id = mdl.Id,
        GenreCode = mdl.GenreCode,
        Title = mdl.Title,
        Year = mdl.Year,
        Rating = mdl.Rating,
        Description = mdl.Description,
        DurationTicks = mdl.DurationTicks
    };

    public static MovieProjection ToProjection(MovieModel mdl) => new MovieProjection()
    {
        Id = mdl.Id,
        GenreCode = mdl.GenreCode,
        Title = mdl.Title,
        Year = mdl.Year,
        Rating = mdl.Rating,
        Description = mdl.Description,
        DurationTicks = mdl.DurationTicks
    };
}