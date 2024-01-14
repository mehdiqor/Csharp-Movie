namespace MovieWatchlist.Exceptions;

public class CustomForbiddenException : Exception
{
    public sealed override string Message { get; }
    public int StatusCode { get; set; }

    public CustomForbiddenException(string message) : base(message)
    {
        Message = message ?? "Forbidden";
        StatusCode = StatusCodes.Status403Forbidden;
    }
}