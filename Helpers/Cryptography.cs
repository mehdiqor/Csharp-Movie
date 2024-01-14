using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using MovieWatchlist.Models;
using System.Text;

namespace MovieWatchlist.Helpers;

public class CryptographyService
{
    private readonly IConfiguration _configuration;

    public CryptographyService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string HashPassword(UserAuth user, string password)
    {
        var passwordHasher = new PasswordHasher<UserAuth>();
        return passwordHasher.HashPassword(user, password);
    }

    public bool CompareHash(UserAuth user, string hashedPassword, string password)
    {
        var passwordHasher = new PasswordHasher<UserAuth>();
        return passwordHasher.VerifyHashedPassword(user, hashedPassword, password) ==
               PasswordVerificationResult.Success;
    }

    public string GenerateJwtToken(string email, string userId)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserId", userId)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(5),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}