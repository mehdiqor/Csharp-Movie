namespace MovieWatchlist.Exceptions;

public class CustomValidationException : Exception
{
    public override string Message { get; }
    public int StatusCode { get; set; }
    public List<string> Errors { get; set; }

    public CustomValidationException(List<string> errors)
    {
        Message = "Validation Error";
        Errors = errors;
        StatusCode = StatusCodes.Status422UnprocessableEntity;
    }
}