using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;

namespace MoviesTest.Web.Api.BusinessLayer.Services;

public class ReservationInvoiceBusinessService : IReservationInvoiceBusinessService
{
    private readonly IReservationBusinessService _svcReservation;
    private readonly ITheaterBusinessService _svcTheater;
    private readonly ITheaterSeatBusinessService _svcTheaterSeat;
    private readonly ITheaterShowTimeBusinessService _svcTheaterShowTime;
    private readonly ITheaterSeatReservationBusinessService _svcTheaterSeatReservation;

    public ReservationInvoiceBusinessService(
        IReservationBusinessService svcReservation,
        ITheaterBusinessService svcTheater,
        ITheaterSeatBusinessService svcTheaterSeat,
        ITheaterShowTimeBusinessService svcTheaterShowTime,
        ITheaterSeatReservationBusinessService svcTheaterSeatReservation)
    {
        _svcReservation = svcReservation;
        _svcTheater = svcTheater;
        _svcTheaterSeat = svcTheaterSeat;
        _svcTheaterShowTime = svcTheaterShowTime;
        _svcTheaterSeatReservation = svcTheaterSeatReservation;
    }

    public async Task<ReservationInvoiceModel> GetReservationInvoice(long reservationId)
    {
        var result = new ReservationInvoiceModel();
        var seats = new List<TheaterSeatModel>();

        result.Reservation = await _svcReservation.GetRecordAggregated(reservationId);
        result.Theater = await _svcTheater.GetRecord(result.Reservation.TheaterId);
        result.TheaterShowTime = await _svcTheaterShowTime.GetRecord(result.Reservation.TheaterShowTimeId);
        result.TheaterSeats = seats;
        
        var seatReservations = await _svcTheaterSeatReservation.GetRecordsForReservation(reservationId);
        foreach (var sr in seatReservations) seats.Add(await _svcTheaterSeat.GetRecord(sr.TheaterSeatId));

        result.TotalPrice = result.TheaterShowTime.TicketPriceUsd + result.TheaterSeats.Sum(x => x.SeatPrice);
        
        return result;
    }
}