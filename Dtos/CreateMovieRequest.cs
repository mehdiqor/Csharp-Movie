namespace Dto.Movie;

public record CreateMovieRequest(
    string Title,
    string Overview
    // List<string> Genres,
);
