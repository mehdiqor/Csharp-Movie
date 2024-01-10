using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
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

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Log the exception
        // You can use any logging framework you prefer

        var errorResponse = new CustomErrorResponse
        {
            Message = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Extensions = new Dictionary<string, object>()
        };

        if (exception is CustomValidationException validationException)
        {
            errorResponse.Message = validationException.Message;
            errorResponse.Status = validationException.StatusCode;
            errorResponse.Extensions["errors"] = validationException.Errors;
        }

        if (exception is CustomBadRequestException badrequestException)
        {
            errorResponse.Message = badrequestException.Message;
            errorResponse.Status = badrequestException.StatusCode;
        }

        if (exception is CustomNotFoundException notFoundException)
        {
            errorResponse.Message = notFoundException.Message;
            errorResponse.Status = notFoundException.StatusCode;
        }

        // Return a standardized error response
        context.Response.StatusCode = errorResponse.Status;
        context.Response.ContentType = "application/problem+json";


        // Write the errorResponse to the response
        return context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
    }
}
