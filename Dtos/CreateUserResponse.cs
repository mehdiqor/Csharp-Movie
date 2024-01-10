namespace UserAuthentication.Contracts.User;

public record CreateUserResponse(
    string Fullname,
    string Email,
    string AccessToken,
    string RefreshToken
);
