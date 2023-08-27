using Microsoft.AspNetCore.Mvc;
using MoviesTest.Sdk.Abstractions;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.Infrastructure;

namespace MoviesTest.Web.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class MovieController : MoviesTestController
{
    private readonly IMovieBusinessService _svcMovie;

    public MovieController(IMovieBusinessService svcMovie)
    {
        _svcMovie = svcMovie;
    }

    #region 'BusinessRepository'
    
    [HttpGet]
    public async Task<ApiResponse<IEnumerable<MovieModel>>> GetRecords()
    {
        var data = await _svcMovie.GetRecords();
        return ApiResponse(data);
    }

    [HttpGet]
    public async Task<ApiResponse<MovieModel>> GetRecord(long id)
    {
        var data = await _svcMovie.GetRecord(id);
        return ApiResponse(data);
    }

    [HttpPost]
    public async Task<ApiResponse<long>> CreateRecord(MovieModel model)
    {
        var data = await _svcMovie.CreateRecord(model);
        return ApiResponse(data);
    }

    [HttpPut]
    public async Task<ApiResponse> UpdateRecord(MovieModel model)
    {
        await _svcMovie.UpdateRecord(model);
        return ApiResponse();
    }

    [HttpDelete]
    public async Task<ApiResponse> DeleteRecord(long id)
    {
        await _svcMovie.DeleteRecord(id);
        return ApiResponse();
    }
    
    #endregion
    
}