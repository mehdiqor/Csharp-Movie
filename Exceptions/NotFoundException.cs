public class CustomNotFoundException : Exception
{
    public string Message { get; set; }
    public int StatusCode { get; set; }

    public CustomNotFoundException(string message) : base(message)
    {
        Message = message ?? "NotFound";
        StatusCode = StatusCodes.Status404NotFound;
    }
}
