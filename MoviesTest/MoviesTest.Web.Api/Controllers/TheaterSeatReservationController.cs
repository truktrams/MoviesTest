using Microsoft.AspNetCore.Mvc;
using MoviesTest.Sdk.Abstractions;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.Infrastructure;

namespace MoviesTest.Web.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TheaterSeatReservationController : MoviesTestController
{
    private readonly ITheaterSeatReservationBusinessService _svcTheaterSeatReservation;

    public TheaterSeatReservationController(ITheaterSeatReservationBusinessService svcTheaterSeatReservation)
    {
        _svcTheaterSeatReservation = svcTheaterSeatReservation;
    }

    #region 'BusinessRepository'
    
    [HttpGet]
    public async Task<ApiResponse<IEnumerable<TheaterSeatReservationModel>>> GetRecords()
    {
        var data = await _svcTheaterSeatReservation.GetRecords();
        return ApiResponse(data);
    }

    [HttpGet]
    public async Task<ApiResponse<TheaterSeatReservationModel>> GetRecord(long id)
    {
        var data = await _svcTheaterSeatReservation.GetRecord(id);
        return ApiResponse(data);
    }

    [HttpPost]
    public async Task<ApiResponse<long>> CreateRecord(TheaterSeatReservationModel model)
    {
        var data = await _svcTheaterSeatReservation.CreateRecord(model);
        return ApiResponse(data);
    }

    [HttpPut]
    public async Task<ApiResponse> UpdateRecord(TheaterSeatReservationModel model)
    {
        await _svcTheaterSeatReservation.UpdateRecord(model);
        return ApiResponse();
    }

    [HttpDelete]
    public async Task<ApiResponse> DeleteRecord(long id)
    {
        await _svcTheaterSeatReservation.DeleteRecord(id);
        return ApiResponse();
    }
    
    #endregion
    
}