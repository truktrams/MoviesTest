using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.DataLayer.Projections;

namespace MoviesTest.Web.Api.BusinessLayer.Translators;

public class TheaterShowTimeTranslator
{
    public static TheaterShowTimeModel ToBusinessModel(TheaterShowTimeProjection mdl) => new TheaterShowTimeModel()
    {
        Id = mdl.Id,
        TheaterId = mdl.TheaterId,
        MovieId = mdl.MovieId,
        StartDateTimeUtc = mdl.StartDateTimeUtc,
        EndDateTimeUtc = mdl.EndDateTimeUtc,
        TicketPriceUsd = mdl.TicketPriceUsd
    };

    public static TheaterShowTimeProjection ToProjection(TheaterShowTimeModel mdl) => new TheaterShowTimeProjection()
    {
        Id = mdl.Id,
        TheaterId = mdl.TheaterId,
        MovieId = mdl.MovieId,
        StartDateTimeUtc = mdl.StartDateTimeUtc,
        EndDateTimeUtc = mdl.EndDateTimeUtc,
        TicketPriceUsd = mdl.TicketPriceUsd
    };
}