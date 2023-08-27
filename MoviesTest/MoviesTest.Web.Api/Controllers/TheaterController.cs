using Microsoft.AspNetCore.Mvc;
using MoviesTest.Sdk.Abstractions;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.Infrastructure;

namespace MoviesTest.Web.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TheaterController : MoviesTestController
{
    private readonly ITheaterBusinessService _svcTheater;

    public TheaterController(ITheaterBusinessService svcTheater)
    {
        _svcTheater = svcTheater;
    }

    #region 'BusinessRepository'
    
    [HttpGet]
    public async Task<ApiResponse<IEnumerable<TheaterModel>>> GetRecords()
    {
        var data = await _svcTheater.GetRecords();
        return ApiResponse(data);
    }

    [HttpGet]
    public async Task<ApiResponse<TheaterModel>> GetRecord(long id)
    {
        var data = await _svcTheater.GetRecord(id);
        return ApiResponse(data);
    }

    [HttpPost]
    public async Task<ApiResponse<long>> CreateRecord(TheaterModel model)
    {
        var data = await _svcTheater.CreateRecord(model);
        return ApiResponse(data);
    }

    [HttpPut]
    public async Task<ApiResponse> UpdateRecord(TheaterModel model)
    {
        await _svcTheater.UpdateRecord(model);
        return ApiResponse();
    }

    [HttpDelete]
    public async Task<ApiResponse> DeleteRecord(long id)
    {
        await _svcTheater.DeleteRecord(id);
        return ApiResponse();
    }
    
    #endregion
    
}