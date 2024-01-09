using MovieWatchlist.Models;
using MovieWatchlist.ServiceErrors;
using ErrorOr;

namespace MovieWatchlist.Services.Movies;

public class MovieService : IMovieService
{
    private static readonly Dictionary<Guid, Movie> _movies = new();

    public ErrorOr<Created> CreateMovie(Movie movie)
    {
        _movies.Add(movie.Id, movie);

        return Result.Created;
    }

    public ErrorOr<Movie> GetMovie(Guid id)
    {
        if (_movies.TryGetValue(id, out var movie))
        {
            return _movies[id];
        }

        return Errors.Movie.NotFound;
    }

    public ErrorOr<UpsertedMovie> UpsertMovie(Movie movie)
    {
        var IsNewlyCreated = !_movies.ContainsKey(movie.Id);
        _movies[movie.Id] = movie;

        return new UpsertedMovie(IsNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteMovie(Guid id)
    {
        _movies.Remove(id);

        return Result.Deleted;
    }
}