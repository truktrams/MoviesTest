using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.DataLayer.Projections;

namespace MoviesTest.Web.Api.BusinessLayer.Translators;

public class ReservationTranslator
{
    public static ReservationModel ToBusinessModel(ReservationProjection mdl) => new ReservationModel()
    {
        Id = mdl.Id,
        ReservationStateCode = mdl.ReservationStateCode,
        UserId = mdl.UserId,
        TheaterId = mdl.TheaterId,
        TheaterShowTimeId = mdl.TheaterShowTimeId,
        ReservedAt = mdl.ReservedAt,
        ApprovalKey = mdl.ApprovalKey
    };

    public static ReservationProjection ToProjection(ReservationModel mdl) => new ReservationProjection()
    {
        Id = mdl.Id,
        ReservationStateCode = mdl.ReservationStateCode,
        UserId = mdl.UserId,
        TheaterId = mdl.TheaterId,
        TheaterShowTimeId = mdl.TheaterShowTimeId,
        ReservedAt = mdl.ReservedAt,
        ApprovalKey = mdl.ApprovalKey
    };
}