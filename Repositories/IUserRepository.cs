using UserAuthentication.Models;
using Dto.User;

namespace Repositories.User;

public interface IUserRepository
{
   Task AddNewUser(UserAuth user);
   Task<FindUserResponse?> FindUserByEmail(string email);
}
