using MovieWatchlist.Dtos;

namespace MovieWatchlist.Managers;

public interface IUserManager
{
    Task<ServiceResponse> SignupUser(CreateUser data);
    Task<ServiceResponse> SigninUser(SigninRequest data);
    Task<ServiceResponse> GetMyProfile(string email);
}