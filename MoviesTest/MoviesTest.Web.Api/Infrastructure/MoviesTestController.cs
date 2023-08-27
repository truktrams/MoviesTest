using Microsoft.AspNetCore.Mvc;
using MoviesTest.Sdk.Abstractions;

namespace MoviesTest.Web.Api.Infrastructure;

public class MoviesTestController : ControllerBase
{
    private readonly DateTimeOffset _requestStartedAt = DateTimeOffset.Now;

    protected ApiResponse ApiResponse()
    {
        var finishedAtTime = DateTimeOffset.Now;
        return new ApiResponse()
        {
            IsSuccess = true,
            FinishedAt = finishedAtTime,
            RequestDurationMilliseconds = finishedAtTime.Millisecond - _requestStartedAt.Millisecond
        };
    }

    protected ApiResponse<TPayloadType> ApiResponse<TPayloadType>(TPayloadType data)
    {
        var finishedAtTime = DateTimeOffset.Now;
        return new ApiResponse<TPayloadType>()
        {
            Data = data,
            IsSuccess = true,
            FinishedAt = finishedAtTime,
            RequestDurationMilliseconds = finishedAtTime.Millisecond - _requestStartedAt.Millisecond
        };
    }
}