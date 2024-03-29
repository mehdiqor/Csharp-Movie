using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using MovieWatchlist.Managers;
using MovieWatchlist.Dtos;
using MovieWatchlist.Helpers;
using MovieWatchlist.Middlewares;

namespace MovieWatchlist.Controllers;

public class UsersController : ApiController
{
    private readonly IRequestCounter _requestCounter;
    private readonly IUserManager _userManager;

    public UsersController(
        IRequestCounter requestCounter,
        IUserManager userManager
    )
    {
        _requestCounter = requestCounter;
        _userManager = userManager;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignupUser(CreateUser request)
    {
        _requestCounter.Increment();

        var result = await _userManager.SignupUser(request);
        return Ok(result);
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SigninUser(SigninRequest request)
    {
        _requestCounter.Increment();

        var result = await _userManager.SigninUser(request);
        return Ok(result);
    }

    [HttpGet("profile")]
    [JwtAuthorize]
    public async Task<IActionResult> GetMyProfile()
    {
        _requestCounter.Increment();

        var payload = HttpContext.Items["Payload"] as JwtPayload;

        var email = payload?.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value;

        if (email == null)
        {
            return BadRequest("Missing email in JWT payload");
        }

        var result = await _userManager.GetMyProfile(email);
        return Ok(result);
    }
}
