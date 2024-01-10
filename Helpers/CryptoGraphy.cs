using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using UserAuthentication.Models;
using System.Security.Claims;
using System.Text;

namespace Cryptography;

public class CryptographyService
{
    private readonly IConfiguration _configuration;

    public CryptographyService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string HashPassword(string password)
    {
        var passwordHasher = new PasswordHasher<UserAuth>();
        return passwordHasher.HashPassword(null, password);
    }

    public bool CompareHash(string hashedPassword, string password)
    {
        var passwordHasher = new PasswordHasher<UserAuth>();
        return passwordHasher.VerifyHashedPassword(null, hashedPassword, password) == PasswordVerificationResult.Success;
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
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddDays(5),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
