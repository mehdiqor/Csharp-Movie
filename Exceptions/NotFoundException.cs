namespace MovieWatchlist.Exceptions;

public class CustomNotFoundException : Exception
{
    public override string Message { get; }
    public int StatusCode { get; set; }

    public CustomNotFoundException(string message) : base(message)
    {
        Message = message ?? "NotFound";
        StatusCode = StatusCodes.Status404NotFound;
    }
}