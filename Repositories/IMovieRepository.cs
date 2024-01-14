using MovieWatchlist.Models;
using MovieWatchlist.Dtos;

namespace MovieWatchlist.Repositories;

public interface IMovieRepository
{
    Task CreateMovie(Movie data);

    Task<GetMovieResponse> GetOneMovie(Guid id);

    Task UpdateMovie(Movie data);

    Task DeleteMovie(Guid id);
}
