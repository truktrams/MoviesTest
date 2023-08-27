using System.Collections.Immutable;

namespace MoviesTest.Web.Api.DataLayer.Projections;

public class ReservationProjection
{
    public long Id { get; set; }
    public string ReservationStateCode { get; set; }
    public long UserId { get; set; }
    public long TheaterId { get; set; }
    public long TheaterShowTimeId { get; set; }
    public DateTimeOffset ReservedAt { get; set; }
    public Guid? ApprovalKey { get; set; }
}