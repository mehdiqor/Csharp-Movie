public class CustomErrorResponse
{
    public string? Message { get; set; }
    public int Status { get; set; }
    public Dictionary<string, object>? Extensions { get; set; }
}
