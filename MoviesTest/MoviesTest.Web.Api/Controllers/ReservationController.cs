using Microsoft.AspNetCore.Mvc;
using MoviesTest.Sdk.Abstractions;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.Infrastructure;

namespace MoviesTest.Web.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ReservationController : MoviesTestController
{
    private readonly IReservationBusinessService _svcReservation;

    public ReservationController(IReservationBusinessService svcReservation)
    {
        _svcReservation = svcReservation;
    }

    #region 'BusinessRepository'
    
    [HttpGet]
    public async Task<ApiResponse<IEnumerable<ReservationModel>>> GetRecords()
    {
        var data = await _svcReservation.GetRecords();
        return ApiResponse(data);
    }

    [HttpGet]
    public async Task<ApiResponse<ReservationModel>> GetRecord(long id)
    {
        var data = await _svcReservation.GetRecord(id);
        return ApiResponse(data);
    }

    [HttpPost]
    public async Task<ApiResponse<long>> CreateRecord(ReservationModel model)
    {
        var data = await _svcReservation.CreateRecord(model);
        return ApiResponse(data);
    }

    [HttpPut]
    public async Task<ApiResponse> UpdateRecord(ReservationModel model)
    {
        await _svcReservation.UpdateRecord(model);
        return ApiResponse();
    }

    [HttpDelete]
    public async Task<ApiResponse> DeleteRecord(long id)
    {
        await _svcReservation.DeleteRecord(id);
        return ApiResponse();
    }
    
    #endregion

    #region 'BusinessRepositoryAggregated'
    
    [HttpGet]
    public async Task<ApiResponse<IEnumerable<ReservationModel>>> GetRecordsAggregated()
    {
        var data = await _svcReservation.GetRecordsAggregated();
        return ApiResponse(data);
    }

    [HttpGet]
    public async Task<ApiResponse<ReservationModel>> GetRecordAggregated(long id)
    {
        var data = await _svcReservation.GetRecordAggregated(id);
        return ApiResponse(data);
    }

    [HttpPost]
    public async Task<ApiResponse<long>> CreateRecordAggregated(ReservationModel model)
    {
        var data = await _svcReservation.CreateRecordAggregated(model);
        return ApiResponse(data);
    }

    [HttpPut]
    public async Task<ApiResponse> UpdateRecordAggregated(ReservationModel model)
    {
        await _svcReservation.UpdateRecordAggregated(model);
        return ApiResponse();
    }

    [HttpDelete]
    public async Task<ApiResponse> DeleteRecordAggregated(long id)
    {
        await _svcReservation.DeleteRecordAggregated(id);
        return ApiResponse();
    }
    
    #endregion

    [HttpGet]
    public async Task<ApiResponse> ApproveReservation(Guid approvalKey)
    {
        await _svcReservation.ApproveReservation(approvalKey);
        return ApiResponse();
    }

    [HttpGet]
    public async Task<ApiResponse> ExpireReservations()
    {
        await _svcReservation.ExpireReservations();
        return ApiResponse();
    }
}