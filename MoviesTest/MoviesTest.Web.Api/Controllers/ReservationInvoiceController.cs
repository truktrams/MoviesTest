using Microsoft.AspNetCore.Mvc;
using MoviesTest.Sdk.Abstractions;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.Infrastructure;

namespace MoviesTest.Web.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ReservationInvoiceController : MoviesTestController
{
    private readonly IReservationInvoiceBusinessService _svcReservationInvoice;

    public ReservationInvoiceController(IReservationInvoiceBusinessService svcReservationInvoice)
    {
        _svcReservationInvoice = svcReservationInvoice;
    }

    [HttpGet]
    public async Task<ApiResponse<ReservationInvoiceModel>> GetReservationInvoice(long reservationId)
    {
        return ApiResponse(await _svcReservationInvoice.GetReservationInvoice(reservationId));
    }
}