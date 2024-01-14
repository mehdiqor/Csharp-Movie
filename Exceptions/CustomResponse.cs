namespace MovieWatchlist.Exceptions;

public class CustomErrorResponse
{
    public CustomErrorResponse(Dictionary<string, object>? extensions)
    {
        Extensions = extensions;
    }

    public string? Message { get; set; }
    public int Status { get; set; }
    public Dictionary<string, object>? Extensions { get; init; }
}