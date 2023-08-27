namespace MoviesTest.Sdk.Abstractions;

public class ApiResponse<TPayloadType>
{
    public TPayloadType Data { get; set; }
    public DateTimeOffset FinishedAt { get; set; }
    public long RequestDurationMilliseconds { get; set; }
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
    public string StackTrace { get; set; }
}

public class ApiResponse
{
    public DateTimeOffset FinishedAt { get; set; }
    public long RequestDurationMilliseconds { get; set; }
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
    public string StackTrace { get; set; }
}