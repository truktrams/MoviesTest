using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.DataLayer.Projections;

namespace MoviesTest.Web.Api.BusinessLayer.Translators;

public class GenreTranslator
{
    public static GenreModel ToBusinessModel(GenreProjection mdl) => new GenreModel()
    {
        Code = mdl.Code,
        Title = mdl.Title
    };

    public static GenreProjection ToProjection(GenreModel mdl) => new GenreProjection()
    {
        Code = mdl.Code,
        Title = mdl.Title
    };
}