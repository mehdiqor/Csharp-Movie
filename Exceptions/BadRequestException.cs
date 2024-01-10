public class CustomBadRequestException : Exception
{
    public string Message { get; set; }
    public int StatusCode { get; set; }

    public CustomBadRequestException(string message) : base(message)
    {
        Message = message ?? "BadRequest";
        StatusCode = StatusCodes.Status400BadRequest;
    }
}
