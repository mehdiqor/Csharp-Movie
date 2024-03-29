using MovieWatchlist.Dtos;

namespace MovieWatchlist.Services;

public interface IUserService
{
    Task<ServiceResponse> SignupUser(CreateUser data);
    Task<ServiceResponse> SigninUser(SigninRequest data);
    Task<ServiceResponse> GetMyProfile(string email);
}
