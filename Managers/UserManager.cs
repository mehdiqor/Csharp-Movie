using Services.User;
using Dto.User;

public class UserManager
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

    public async Task<string> SignupUser(CreateUser data)
    {
        var validator = new SignupValidator();
        var validationResult = validator.Validate(data);

        if (!validationResult.IsValid)
        {
            List<string> errors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(error.ErrorMessage);
            }

            _logger.LogWarning("Invalid input for signup");
            throw new CustomValidationException(errors);
        }

        _logger.LogInformation("Input validated for signup");
        return await _userService.SignupUser(data);
    }

    public async Task<SigninResponse> SigninUser(SigninRequest data)
    {
        var validator = new SigninValidator();
        var validationResult = validator.Validate(data);

        if (!validationResult.IsValid)
        {
            List<string> errors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(error.ErrorMessage);
            }

            _logger.LogWarning("Invalid input for signin");
            throw new CustomValidationException(errors);
        }

        _logger.LogInformation("Input validated for signin");
        return await _userService.SigninUser(data);
    }

    public async Task<GetUserProfileResponse> GetMyProfile(string email)
    {
        return await _userService.GetMyProfile(email);
    }
}
