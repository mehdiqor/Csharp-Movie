using MovieWatchlist.Models;
using Dto.Movie;

namespace Repositories.MovieWatchlist;

public interface IMovieRepository
{
    Task CreateMovie(Movie data);

    Task<GetMovieResponse> GetOneMovie(Guid id);

    Task UpdateMovie(Movie data);

    Task DeleteMovie(Guid id);
}
