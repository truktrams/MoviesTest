using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.DataLayer.Projections;

namespace MoviesTest.Web.Api.BusinessLayer.Translators;

public class TheaterSeatTranslator
{
    public static TheaterSeatModel ToBusinessModel(TheaterSeatProjection mdl) => new TheaterSeatModel()
    {
        Id = mdl.Id,
        TheaterId = mdl.TheaterId,
        Title = mdl.Title,
        SeatPrice = mdl.SeatPrice
    };

    public static TheaterSeatProjection ToProjection(TheaterSeatModel mdl) => new TheaterSeatProjection()
    {
        Id = mdl.Id,
        TheaterId = mdl.TheaterId,
        Title = mdl.Title,
        SeatPrice = mdl.SeatPrice
    };
}