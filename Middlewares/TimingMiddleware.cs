using System.Globalization;

namespace MovieWatchlist.Middlewares;

public class TimingMiddleware
{
    private readonly ILogger<TimingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public TimingMiddleware(ILogger<TimingMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext ctx)
    {
        var start = DateTime.UtcNow;
        await _next.Invoke(ctx);

        var path = ctx.Request.Path.ToString();
        var time = ((DateTime.UtcNow - start).TotalMilliseconds).ToString(CultureInfo.InvariantCulture);

        _logger.LogInformation("Timing for request: {Path} => {Time}ms", path, time);
    }
}

public static class TimingExtensions
{
    public static IApplicationBuilder UseTiming(this IApplicationBuilder app)
    {
        return app.UseMiddleware<TimingMiddleware>();
    }
}