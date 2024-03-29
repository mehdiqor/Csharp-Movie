using MovieWatchlist.Dtos;

namespace MovieWatchlist.Services;

public interface IMovieService
{
    Task<ServiceResponse> CreateMovie(CreateMovieRequest data);

    Task<ServiceResponse> GetOneMovie(Guid id);

    Task<ServiceResponse> UpdateMovie(Guid id, CreateMovieRequest data);

    Task<ServiceResponse> DeleteMovie(Guid id);
}