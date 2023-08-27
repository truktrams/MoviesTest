using Microsoft.AspNetCore.Mvc;
using MoviesTest.Sdk.Abstractions;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.Infrastructure;

namespace MoviesTest.Web.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TheaterShowTimeController : MoviesTestController
{
    private readonly ITheaterShowTimeBusinessService _svcTheaterShowTime;

    public TheaterShowTimeController(ITheaterShowTimeBusinessService svcTheaterShowTime)
    {
        _svcTheaterShowTime = svcTheaterShowTime;
    }

    #region 'BusinessRepository'
    
    [HttpGet]
    public async Task<ApiResponse<IEnumerable<TheaterShowTimeModel>>> GetRecords()
    {
        var data = await _svcTheaterShowTime.GetRecords();
        return ApiResponse(data);
    }

    [HttpGet]
    public async Task<ApiResponse<TheaterShowTimeModel>> GetRecord(long id)
    {
        var data = await _svcTheaterShowTime.GetRecord(id);
        return ApiResponse(data);
    }

    [HttpPost]
    public async Task<ApiResponse<long>> CreateRecord(TheaterShowTimeModel model)
    {
        var data = await _svcTheaterShowTime.CreateRecord(model);
        return ApiResponse(data);
    }

    [HttpPut]
    public async Task<ApiResponse> UpdateRecord(TheaterShowTimeModel model)
    {
        await _svcTheaterShowTime.UpdateRecord(model);
        return ApiResponse();
    }

    [HttpDelete]
    public async Task<ApiResponse> DeleteRecord(long id)
    {
        await _svcTheaterShowTime.DeleteRecord(id);
        return ApiResponse();
    }
    
    #endregion
    
}