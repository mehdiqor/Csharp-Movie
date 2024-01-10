using UserAuthentication.Services.Users;
using UserAuthentication.Contracts.User;
using System.IdentityModel.Tokens.Jwt;
using MovieWatchlist.RequestCounter;
using UserAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Cryptography;
using Middlewares;
using ErrorOr;

namespace MovieWatchlist.Controllers;

public class UsersController : ApiController
{
    private readonly IUserService _userService;
    private readonly IRequestCounter _requestCounter;
    private readonly IConfiguration _configuration;
    private readonly CryptographyService _cryptographyService;
    private readonly IJwtValidator _jwtValidator;

    public UsersController(
        IUserService userService,
        IRequestCounter requestCounter,
        IConfiguration configuration,
        CryptographyService cryptographyService,
        IJwtValidator jwtValidator
    )
    {
        _userService = userService;
        _requestCounter = requestCounter;
        _configuration = configuration;
        _cryptographyService = cryptographyService;
        _jwtValidator = jwtValidator;
    }

    /*
    * Signup user
    */
    [HttpPost("signup")]
    public async Task<IActionResult> SignupUser(CreateUserDto request)
    {
        _requestCounter.Increment();

        // Check excistance of user with email. if exist, throw exception
        var extUser = await _userService.FindByEmail(request.Email);
        if (extUser != null)
        {
            return StatusCode(409, "Email is already in use");
        }

        ErrorOr<UserAuth> requestToSignupResult = UserAuth.CreateFrom(request);

        if (requestToSignupResult.IsError)
        {
            return Problem(requestToSignupResult.Errors);
        }

        var user = requestToSignupResult.Value;

        // Hash the password
        user.Password = _cryptographyService.HashPassword(request.Password);

        // Save user in database
        ErrorOr<Created> createUserResult = await _userService.SignupUser(user);

        return createUserResult.Match(
            created => Ok(new { Message = "Signup was successfull" }),
            errors => Problem(errors)
        );
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SigninUser(SigninDto request)
    {
        // Check excistance of user with email. if doesn't exist, throw exception
        var extUser = await _userService.FindByEmail(request.Email);
        if (extUser == null)
        {
            return StatusCode(400, "Email or Password is wrong!");
        }

        // Compare hash
        var result = _cryptographyService.CompareHash(extUser.Password, request.Password);

        if (result == false)
        {
            return StatusCode(400, "Email or Password is wrong!");
        }

        // Generate JWT
        var token = _cryptographyService.GenerateJwtToken(request.Email, extUser.Id.ToString());


        return Ok(new { token });
    }

    [HttpGet("profile")]
    [JwtAuthorize]
    public async Task<IActionResult> GetMe()
    {
        var payload = HttpContext.Items["Payload"] as JwtPayload;

        var email = payload.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value;

        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("Email not found in token.");
        }

        // Find the user by email
        var user = await _userService.FindByEmail(email);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        // Return the user data
        return Ok(user);
    }
}
