namespace Middlewares;

public class VerifyAccessMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public VerifyAccessMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.GetEndpoint();
        var authorizeMetadata = endpoint?.Metadata.GetOrderedMetadata<AuthorizeAttribute>();

        if (authorizeMetadata != null)
        {
            var jwtTokenValidationMiddleware = new JwtTokenValidationMiddleware(_next);
            await jwtTokenValidationMiddleware.InvokeAsync(context, _configuration);
        }

        await _next(context);
    }
}
