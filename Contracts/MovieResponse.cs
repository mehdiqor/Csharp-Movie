namespace MovieWatchlist.Contracts.Movie;

public record MovieResponse(
    Guid Id,
    string Title,
    string Overview,
    // List<string> Genres,
    DateTime CreationDate,
    DateTime LastUpdated
);
