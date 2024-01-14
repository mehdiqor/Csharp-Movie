namespace MovieWatchlist.Exceptions;

public class CustomBadRequestException : Exception
{
    public sealed override string Message { get; }
    public int StatusCode { get; set; }

    public CustomBadRequestException(string message) : base(message)
    {
        Message = message ?? "BadRequest";
        StatusCode = StatusCodes.Status400BadRequest;
    }
}