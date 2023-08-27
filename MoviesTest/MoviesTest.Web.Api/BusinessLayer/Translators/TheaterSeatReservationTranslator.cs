using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.DataLayer.Projections;

namespace MoviesTest.Web.Api.BusinessLayer.Translators;

public class TheaterSeatReservationTranslator
{
    public static TheaterSeatReservationModel ToBusinessModel(TheaterSeatReservationProjection mdl) => new TheaterSeatReservationModel()
    {
        Id = mdl.Id,
        TheaterSeatId = mdl.TheaterSeatId,
        ReservationId = mdl.ReservationId,
        TheaterShowTimeId = mdl.TheaterShowTimeId
    };

    public static TheaterSeatReservationProjection ToProjection(TheaterSeatReservationModel mdl) => new TheaterSeatReservationProjection()
    {
        Id = mdl.Id,
        TheaterSeatId = mdl.TheaterSeatId,
        ReservationId = mdl.ReservationId,
        TheaterShowTimeId = mdl.TheaterShowTimeId
    };
}