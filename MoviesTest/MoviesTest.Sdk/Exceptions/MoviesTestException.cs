namespace MoviesTest.Sdk.Exceptions;

public class MoviesTestException: Exception
{
    public MoviesTestException(): base() { }
    public MoviesTestException(string message): base(message) { }
    public MoviesTestException(string message, Exception innerException): base(message, innerException) { }
}