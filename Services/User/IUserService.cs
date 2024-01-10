using UserAuthentication.Models;
using ErrorOr;

namespace UserAuthentication.Services.Users;

public interface IUserService
{
    Task<ErrorOr<Created>> SignupUser(UserAuth user);

    Task<UserAuth?> FindByEmail(string email);
}