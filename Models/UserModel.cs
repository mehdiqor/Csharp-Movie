using Dto.User;

namespace UserAuthentication.Models;

public class UserAuth
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
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

    public static UserAuth Create(
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
        return Create(
            data.Fullname,
            data.Password,
            data.Email,
            DateTime.UtcNow,
            DateTime.UtcNow,
            Guid.NewGuid()
        );
    }
}
