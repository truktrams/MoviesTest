using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.DataLayer.Projections;

namespace MoviesTest.Web.Api.BusinessLayer.Translators;

public class TheaterTranslator
{
    public static TheaterModel ToBusinessModel(TheaterProjection mdl) => new TheaterModel()
    {
        Id = mdl.Id,
        Title = mdl.Title
    };

    public static TheaterProjection ToProjection(TheaterModel mdl) => new TheaterProjection()
    {
        Id = mdl.Id,
        Title = mdl.Title
    };
}