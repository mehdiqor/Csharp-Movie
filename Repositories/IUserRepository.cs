using MovieWatchlist.Models;
using MovieWatchlist.Dtos;

namespace MovieWatchlist.Repositories;

public interface IUserRepository
{
   Task AddNewUser(UserAuth user);
   Task<UserAuth> FindUserByEmail(string email);
}
