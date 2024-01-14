using MovieWatchlist.Exceptions;
using Newtonsoft.Json;

namespace MovieWatchlist.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Log the exception here

        var errorResponse = new CustomErrorResponse(new Dictionary<string, object>())
        {
            Message = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Extensions = new Dictionary<string, object>()
        };

        switch (exception)
        {
            case CustomValidationException validationException:
                errorResponse.Message = validationException.Message;
                errorResponse.Status = validationException.StatusCode;
                errorResponse.Extensions["errors"] = validationException.Errors;
                break;
            case CustomBadRequestException badRequestException:
                errorResponse.Message = badRequestException.Message;
                errorResponse.Status = badRequestException.StatusCode;
                break;
            case CustomNotFoundException notFoundException:
                errorResponse.Message = notFoundException.Message;
                errorResponse.Status = notFoundException.StatusCode;
                break;
            case CustomForbiddenException forbiddenException:
                errorResponse.Message = forbiddenException.Message;
                errorResponse.Status = forbiddenException.StatusCode;
                break;
        }

        // Return a standardized error response
        context.Response.StatusCode = errorResponse.Status;
        context.Response.ContentType = "application/problem+json";


        // Write the errorResponse to the response
        return context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
    }
}