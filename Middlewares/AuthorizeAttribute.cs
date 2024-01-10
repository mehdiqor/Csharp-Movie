using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Middlewares;

public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authResult = context.HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);

        Console.WriteLine(22222);
        Console.WriteLine(authResult.Result.Succeeded);
        Console.WriteLine(22222);

        if (!authResult.Result.Succeeded)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
