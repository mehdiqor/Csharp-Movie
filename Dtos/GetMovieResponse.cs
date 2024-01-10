namespace Dto.Movie;

public record GetMovieResponse(
    string Id,
    string Title,
    string Overview,
    DateTime CreationDate,
    DateTime LastUpdated
);
