using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoviesTest.Sdk.Abstractions;

namespace MoviesTest.Web.Api.Infrastructure;

public class ExceptionFilterAttribute : Attribute, IExceptionFilter
{
    // TODO: Work on exception handling.
    // TODO: Build message according to environment type.
    public void OnException(ExceptionContext context)
    {
        LogToConsole(context);
        BuildResult(context);
        context.ExceptionHandled = true;
    }

    private void LogToConsole(ExceptionContext context)
    {
        Console.WriteLine(
            $"=========>  E R R O R  <========= \n" +
            $"{context.ActionDescriptor.DisplayName} => request failed with following message: \n" +
            $"  {context.Exception.Message} \n" +
            $"Stack trace:\n" +
            $"{context.Exception.StackTrace} \n");
    }

    private void BuildResult(ExceptionContext context)
    {
        var result = new ApiResponse()
        {
            IsSuccess = false,
            FinishedAt = DateTimeOffset.Now,
            ErrorMessage = context.Exception.Message,
            StackTrace = context.Exception.StackTrace
        };
        context.Result = new JsonResult(result) {StatusCode = 500};
    }
}