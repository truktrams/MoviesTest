using Microsoft.AspNetCore.Mvc;
using MoviesTest.Sdk.Abstractions;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.Infrastructure;

namespace MoviesTest.Web.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class GenreController : MoviesTestController
{
    private readonly IGenreBusinessService _svcGenre;

    public GenreController(IGenreBusinessService svcGenre)
    {
        _svcGenre = svcGenre;
    }

    #region 'BusinessRepository'
    
    [HttpGet]
    public async Task<ApiResponse<IEnumerable<GenreModel>>> GetRecords()
    {
        var data = await _svcGenre.GetRecords();
        return ApiResponse(data);
    }

    [HttpGet]
    public async Task<ApiResponse<GenreModel>> GetRecord(string code)
    {
        var data = await _svcGenre.GetRecord(code);
        return ApiResponse(data);
    }

    [HttpPost]
    public async Task<ApiResponse<string>> CreateRecord(GenreModel model)
    {
        var data = await _svcGenre.CreateRecord(model);
        return ApiResponse(data);
    }

    [HttpPut]
    public async Task<ApiResponse> UpdateRecord(GenreModel model)
    {
        await _svcGenre.UpdateRecord(model);
        return ApiResponse();
    }

    [HttpDelete]
    public async Task<ApiResponse> DeleteRecord(string code)
    {
        await _svcGenre.DeleteRecord(code);
        return ApiResponse();
    }
    
    #endregion
    
}