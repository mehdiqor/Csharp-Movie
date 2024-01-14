namespace MovieWatchlist.Dtos;

public record GetUserProfileResponse(
    string Id,
    string Fullname,
    string Email,
    DateTime CreationDate,
    DateTime LastUpdated
);
