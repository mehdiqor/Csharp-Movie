namespace MovieWatchlist.Dtos;

public record CreateUser(
    string Fullname,
    string Password,
    string Email
);
