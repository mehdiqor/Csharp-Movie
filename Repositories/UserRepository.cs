using Microsoft.EntityFrameworkCore;
using UserAuthentication.Models;
using DatabaseConnection;
using Dto.User;

namespace Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly MovieDbContext _context;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(MovieDbContext context, ILogger<UserRepository> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task AddNewUser(UserAuth user)
    {
        try
        {
            _context.Users?.Add(user);
            await _context.SaveChangesAsync();

            _logger.LogInformation("User successfully saved in database");
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "An error occurred while adding a new user");
            throw;
        }
    }

    public async Task<FindUserResponse?> FindUserByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null)
        {
            return new FindUserResponse(
                user.Id.ToString(),
                user.Fullname,
                user.Email,
                user.Password,
                user.CreationDate,
                user.LastUpdated
            );
        }
        else
        {
            _logger.LogWarning($"No user found with email: {email}");
            return null;
        }
    }
}
