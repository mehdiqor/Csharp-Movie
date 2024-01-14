using MovieWatchlist.Dtos;
using MovieWatchlist.Exceptions;
using MovieWatchlist.Services;

// TODO: fix namespaces
// TODO: create interface for managers

namespace MovieWatchlist.Managers;

public class UserManager : IUserManager
{
    private readonly IUserService _userService;
    private readonly ILogger<UserService> _logger;

    public UserManager(
        IUserService userService,
        ILogger<UserService> logger
    )
    {
        _userService = userService;
        _logger = logger;
    }

    public async Task<ServiceResponse> SignupUser(CreateUser data)
    {
        var validator = new SignupValidator();
        // TODO: change validations to ValidateAsync
        var validationResult = await validator.ValidateAsync(data);

        if (!validationResult.IsValid)
        {
            // TODO: change error handling logic and use LINQ expression
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

            _logger.LogWarning("Invalid input for signup");
            throw new CustomValidationException(errors);
        }

        _logger.LogInformation("Input validated for signup");

        return await _userService.SignupUser(data);
    }

    public async Task<ServiceResponse> SigninUser(SigninRequest data)
    {
        var validator = new SigninValidator();
        var validationResult = await validator.ValidateAsync(data);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

            _logger.LogWarning("Invalid input for signin");
            throw new CustomValidationException(errors);
        }

        _logger.LogInformation("Input validated for signin");
        return await _userService.SigninUser(data);
    }

    public async Task<ServiceResponse> GetMyProfile(string email)
    {
        return await _userService.GetMyProfile(email);
    }
}