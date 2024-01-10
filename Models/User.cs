using UserAuthentication.Contracts.User;
using System.Text.RegularExpressions;
using UserAuthentication.UserErrors;
using ErrorOr;

namespace UserAuthentication.Models;

public class UserAuth
{
    /*
    * Validations
    */
    public const int MinFullnameLength = 5;
    public const int MaxFullnameLength = 20;
    public const int MinPasswordLength = 8;
    public const int MaxPasswordLength = 20;
    public const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    /*
    * Fields
    */
    public Guid Id { get; set; }
    public string? Fullname { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdated { get; set; }

    private UserAuth()
    {
    }

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

    public static ErrorOr<UserAuth> Create(
      string fullname,
      string password,
      string email,
      DateTime creationDate,
      DateTime lastUpdated,
      Guid id
  )
    {
        List<Error> errors = new();

        if (fullname.Length is < MinFullnameLength or > MaxFullnameLength)
        {
            errors.Add(Errors.UserErros.InvalidFulname);
        }

        if (password.Length is < MinPasswordLength or > MaxPasswordLength)
        {
            errors.Add(Errors.UserErros.InvalidPassword);
        }

        Regex regex = new Regex(EmailPattern);
        if (!regex.IsMatch(email))
        {
            errors.Add(Errors.UserErros.InvalidEmail);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new UserAuth(
          id,
          fullname,
          password,
          email,
          creationDate,
          lastUpdated
      );
    }

    public static ErrorOr<UserAuth> CreateFrom(CreateUserDto request)
    {
        return Create(
            request.Fullname,
            request.Password,
            request.Email,
            DateTime.UtcNow,
            DateTime.UtcNow,
            Guid.NewGuid()
        );
    }
}
