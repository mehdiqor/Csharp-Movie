using Dto.User;

namespace Services.User;

public interface IUserService
{
    Task<string> SignupUser(CreateUser data);
    Task<SigninResponse> SigninUser(SigninRequest data);
    Task<GetUserProfileResponse> GetMyProfile(string email);
}
