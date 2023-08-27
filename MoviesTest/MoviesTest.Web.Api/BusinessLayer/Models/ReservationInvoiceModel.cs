using FluentAssertions;

namespace MoviesTest.Web.Api.BusinessLayer.Models;

public class ReservationInvoiceModel
{
    public ReservationModel Reservation { get; set; }
    public TheaterModel Theater { get; set; }
    public IEnumerable<TheaterSeatModel> TheaterSeats { get; set; }
    public TheaterShowTimeModel TheaterShowTime { get; set; }

    public double TotalPrice { get; set; }

    public void Validate()
    {
    }
}