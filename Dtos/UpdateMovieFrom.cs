namespace MovieWatchlist.Dtos;

public record UpdateMovieFrom(
    string Title,
    string Overview,
    DateTime CreationDate
);