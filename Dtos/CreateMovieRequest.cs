namespace MovieWatchlist.Dtos;

public record CreateMovieRequest(
    string Title,
    string Overview
    // List<string> Genres,
);
