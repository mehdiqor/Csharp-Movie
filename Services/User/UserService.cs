using MovieWatchlist.DatabaseConnection;
using Microsoft.EntityFrameworkCore;
using UserAuthentication.UserErrors;
using UserAuthentication.Models;
using ErrorOr;

namespace UserAuthentication.Services.Users;

public class UserService : IUserService
{
    private readonly MovieDbContext _context;

    public UserService(MovieDbContext context)
    {
        _context = context;
    }

    public async Task<ErrorOr<Created>> SignupUser(UserAuth user)
    {
        _context.Users?.Add(user);
        await _context.SaveChangesAsync();

        return Result.Created;
    }

    public async Task<UserAuth?> FindByEmail(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
    }
}
