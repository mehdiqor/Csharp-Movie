namespace MovieWatchlist.Contracts.Movie;

public record CreateMovieRequest(
    string Title,
    string Overview,
    // List<string> Genres,
    DateTime CreationDate,
    DateTime LastUpdated
);
