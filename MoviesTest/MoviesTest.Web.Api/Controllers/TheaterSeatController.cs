using Microsoft.AspNetCore.Mvc;
using MoviesTest.Sdk.Abstractions;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.Infrastructure;

namespace MoviesTest.Web.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TheaterSeatController : MoviesTestController
{
    private readonly ITheaterSeatBusinessService _svcTheaterSeat;

    public TheaterSeatController(ITheaterSeatBusinessService svcTheaterSeat)
    {
        _svcTheaterSeat = svcTheaterSeat;
    }

    #region 'BusinessRepository'
    
    [HttpGet]
    public async Task<ApiResponse<IEnumerable<TheaterSeatModel>>> GetRecords()
    {
        var data = await _svcTheaterSeat.GetRecords();
        return ApiResponse(data);
    }

    [HttpGet]
    public async Task<ApiResponse<TheaterSeatModel>> GetRecord(long id)
    {
        var data = await _svcTheaterSeat.GetRecord(id);
        return ApiResponse(data);
    }

    [HttpPost]
    public async Task<ApiResponse<long>> CreateRecord(TheaterSeatModel model)
    {
        var data = await _svcTheaterSeat.CreateRecord(model);
        return ApiResponse(data);
    }

    [HttpPut]
    public async Task<ApiResponse> UpdateRecord(TheaterSeatModel model)
    {
        await _svcTheaterSeat.UpdateRecord(model);
        return ApiResponse();
    }

    [HttpDelete]
    public async Task<ApiResponse> DeleteRecord(long id)
    {
        await _svcTheaterSeat.DeleteRecord(id);
        return ApiResponse();
    }
    
    #endregion
    
}