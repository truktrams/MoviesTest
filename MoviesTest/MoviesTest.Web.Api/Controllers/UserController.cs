using Microsoft.AspNetCore.Mvc;
using MoviesTest.Sdk.Abstractions;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.Infrastructure;

namespace MoviesTest.Web.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : MoviesTestController
{
    private readonly IUserBusinessService _svcUser;

    public UserController(IUserBusinessService svcUser)
    {
        _svcUser = svcUser;
    }

    #region 'BusinessRepository'
    
    [HttpGet]
    public async Task<ApiResponse<IEnumerable<UserModel>>> GetRecords()
    {
        var data = await _svcUser.GetRecords();
        return ApiResponse(data);
    }

    [HttpGet]
    public async Task<ApiResponse<UserModel>> GetRecord(long id)
    {
        var data = await _svcUser.GetRecord(id);
        return ApiResponse(data);
    }

    [HttpPost]
    public async Task<ApiResponse<long>> CreateRecord(UserModel model)
    {
        var data = await _svcUser.CreateRecord(model);
        return ApiResponse(data);
    }

    [HttpPut]
    public async Task<ApiResponse> UpdateRecord(UserModel model)
    {
        await _svcUser.UpdateRecord(model);
        return ApiResponse();
    }

    [HttpDelete]
    public async Task<ApiResponse> DeleteRecord(long id)
    {
        await _svcUser.DeleteRecord(id);
        return ApiResponse();
    }
    
    #endregion
    
}