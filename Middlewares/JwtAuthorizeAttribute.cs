using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using MovieWatchlist.Exceptions;

namespace MovieWatchlist.Middlewares;

public class JwtAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var jwtValidator = context.HttpContext.RequestServices.GetRequiredService<IJwtValidator>();

        var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        var result = token != null && jwtValidator.ValidateToken(token);

        if (string.IsNullOrEmpty(token) || !result)
        {
            throw new CustomForbiddenException("Invalid token");
        }

        // Extract the payload from the token
        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.ReadJwtToken(token);
        var payload = securityToken.Payload;

        // Store the payload in HttpContext.Items for later retrieval
        context.HttpContext.Items["Payload"] = payload;
    }
}