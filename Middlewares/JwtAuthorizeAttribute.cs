using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Middlewares;

public class JwtAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var jwtValidator = context.HttpContext.RequestServices.GetRequiredService<IJwtValidator>();

        var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        var result = jwtValidator.ValidateToken(token);

        if (string.IsNullOrEmpty(token) || !result)
        {
            context.Result = new ContentResult()
            {
                StatusCode = 403,
                Content = "No token provided or Invalid token"
            };
            return;
        }

        // Extract the payload from the token
        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.ReadJwtToken(token);
        var payload = securityToken.Payload;

        // Store the payload in HttpContext.Items for later retrieval
        context.HttpContext.Items["Payload"] = payload;
    }
}

