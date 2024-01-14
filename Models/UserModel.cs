using System.ComponentModel.DataAnnotations;
using MovieWatchlist.Dtos;

namespace MovieWatchlist.Models;

public class UserAuth
{
    public Guid Id { get; set; }
    [MaxLength(20)] public string Fullname { get; set; }
    [MaxLength(16)] public string Password { get; set; }
    [MaxLength(254)] public string Email { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdated { get; set; }

    private UserAuth(
        Guid id,
        string fullname,
        string password,
        string email,
        DateTime creationDate,
        DateTime lastUpdated
    )
    {
        Id = id;
        Fullname = fullname;
        Password = password;
        Email = email;
        CreationDate = creationDate;
        LastUpdated = lastUpdated;
    }

    private static UserAuth Create(
        string fullname,
        string password,
        string email,
        DateTime creationDate,
        DateTime lastUpdated,
        Guid id
    )
    {
        return new UserAuth(
            id,
            fullname,
            password,
            email,
            creationDate,
            lastUpdated
        );
    }

    public static UserAuth CreateFrom(CreateUser data)
    {
        var now = DateTime.UtcNow;

        return Create(
            data.Fullname,
            data.Password,
            data.Email,
            now,
            now,
            Guid.NewGuid()
        );
    }
}