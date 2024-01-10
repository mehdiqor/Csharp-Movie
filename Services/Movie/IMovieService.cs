using MovieWatchlist.Models;
using ErrorOr;

namespace MovieWatchlist.Services.Movies;

public interface IMovieService
{
    ErrorOr<Created> CreateMovie(Movie movie);

    ErrorOr<Movie> GetMovie(Guid id);

    ErrorOr<Updated> UpsertMovie(Movie movie);

    ErrorOr<Deleted> DeleteMovie(Guid id);
}