namespace MovieWatchlist.Dtos;

public record FindUserResponse(
    string Id,
    string Fullname,
    string Email,
    string Password,
    DateTime CreationDate,
    DateTime LastUpdated
);
