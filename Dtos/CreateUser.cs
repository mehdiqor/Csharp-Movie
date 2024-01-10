namespace Dto.User;

public record CreateUser(
    string Fullname,
    string Password,
    string Email
);
