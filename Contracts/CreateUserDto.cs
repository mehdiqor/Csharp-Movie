namespace UserAuthentication.Contracts.User;

public record CreateUserDto(
    string Fullname,
    string Password,
    string Email,
    DateTime CreationDate,
    DateTime LastUpdated
);
