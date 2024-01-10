namespace Dto.Movie;

public record CreateMovieResponse(
    string Id,
    string Title,
    string Overview,
    // List<string> Genres,
    DateTime CreationDate,
    DateTime LastUpdated
);
