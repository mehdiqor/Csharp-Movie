using UserAuthentication.Models;
using Repositories.User;
using Cryptography;
using Dto.User;

namespace Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly CryptographyService _cryptographyService;
    private readonly ILogger<UserService> _logger;

    public UserService(
        IUserRepository userRepository,
        CryptographyService cryptographyService,
        ILogger<UserService> logger
    )
    {
        _userRepository = userRepository;
        _cryptographyService = cryptographyService;
        _logger = logger;
    }

    public async Task<string> SignupUser(CreateUser data)
    {
        try
        {
            // Check excistance of user with email. if user exist, throw exception
            var extUser = await _userRepository.FindUserByEmail(data.Email);
            if (extUser != null)
            {
                _logger.LogWarning($"User with email {data.Email} already exists.");
                throw new CustomBadRequestException("User with email already exists");
            }

            var user = UserAuth.CreateFrom(data);
            await _userRepository.AddNewUser(user);

            _logger.LogInformation("User signed up successfully");
            return "Signup was successfull";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while signing up the user");
            throw;
        }
    }

    public async Task<SigninResponse> SigninUser(SigninRequest data)
    {
        try
        {
            // Check excistance of user with email. if doesn't exist, throw exception
            var extUser = await _userRepository.FindUserByEmail(data.Email);
            if (extUser == null)
            {
                _logger.LogWarning($"User not found with the provided email {data.Email}");
                throw new CustomBadRequestException("Email or Password is wrong!");
            }

            // // Compare hash
            var result = _cryptographyService.CompareHash(extUser.Password, data.Password);

            if (result == false)
            {
                _logger.LogWarning("Invalid password");
                throw new CustomBadRequestException("Email or Password is wrong!");
            }

            // Generate JWT
            var token = _cryptographyService.GenerateJwtToken(extUser.Email, extUser.Id.ToString());


            _logger.LogInformation("User signed in successfully");
            return new SigninResponse(token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while signing in the user");
            throw;
        }
    }

    public async Task<GetUserProfileResponse> GetMyProfile(string email)
    {
        try
        {
            _logger.LogInformation($"Attempting to get user profile for email: {email}");

            var user = await _userRepository.FindUserByEmail(email);
            if (user == null)
            {
                _logger.LogWarning($"User not found for email: {email}");
                throw new CustomNotFoundException("User NotFound");
            }
            _logger.LogInformation("User profile retrieved successfully");

            return new GetUserProfileResponse(
                user.Id,
                user.Fullname,
                user.Email,
                user.CreationDate,
                user.LastUpdated
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while getting user profile for email: {email}");
            throw;
        }
    }
}
