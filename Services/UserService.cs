using MovieWatchlist.Repositories;
using MovieWatchlist.Exceptions;
using MovieWatchlist.Helpers;
using MovieWatchlist.Models;
using MovieWatchlist.Dtos;

namespace MovieWatchlist.Services;

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

    public async Task<ServiceResponse> SignupUser(CreateUser data)
    {
        try
        {
            // Check existence of user with email. if user exist, throw exception
            var extUser = await _userRepository.FindUserByEmail(data.Email);
            if (extUser != null)
            {
                _logger.LogWarning("User with email {email} already exists", data.Email);
                throw new CustomBadRequestException("User with email already exists");
            }

            var hashedPassword = _cryptographyService.HashPassword(extUser, data.Password);

            var hashedData = new CreateUser(
                Fullname: data.Fullname,
                Email: data.Email,
                Password: hashedPassword
            );

            var user = UserAuth.CreateFrom(hashedData);
            await _userRepository.AddNewUser(user);

            _logger.LogInformation("User signed up successfully");

            return new ServiceResponse(
                Message: "Signup was successful",
                Data: new { }
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while signing up the user");
            throw;
        }
    }

    public async Task<ServiceResponse> SigninUser(SigninRequest data)
    {
        try
        {
            // Check existence of user with email. if doesn't exist, throw exception
            var extUser = await _userRepository.FindUserByEmail(data.Email);
            if (extUser == null)
            {
                _logger.LogWarning("User not found with the provided email {email}", data.Email);
                throw new CustomBadRequestException("Email or Password is wrong!");
            }

            // // Compare hash
            var result = _cryptographyService.CompareHash(extUser, extUser.Password, data.Password);

            if (result == false)
            {
                _logger.LogWarning("Invalid password");
                throw new CustomBadRequestException("Email or Password is wrong!");
            }

            // Generate JWT
            var token = _cryptographyService.GenerateJwtToken(extUser.Email, extUser.Id.ToString());


            _logger.LogInformation("User signed in successfully");

            return new ServiceResponse(
                Message: "You signed in successfully",
                Data: new { token }
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while signing in the user");
            throw;
        }
    }

    public async Task<ServiceResponse> GetMyProfile(string email)
    {
        try
        {
            _logger.LogInformation("Attempting to get user profile for email: {email}", email);

            var user = await _userRepository.FindUserByEmail(email);
            if (user == null)
            {
                _logger.LogWarning("User not found for email: {email}", email);
                throw new CustomNotFoundException("User NotFound");
            }

            _logger.LogInformation("User profile retrieved successfully");

            var response = new GetUserProfileResponse(
                user.Id.ToString(),
                user.Fullname,
                user.Email,
                user.CreationDate,
                user.LastUpdated
            );

            return new ServiceResponse(
                Message: "OK",
                Data: response
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting user profile for email: {email}", email);
            throw;
        }
    }
}