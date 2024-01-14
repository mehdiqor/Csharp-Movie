using MovieWatchlist.Dtos;

namespace MovieWatchlist.Managers;

public interface IMovieManager
{
    Task<ServiceResponse> CreateMovie(CreateMovieRequest data);
    Task<ServiceResponse> GetOneMovie(Guid id);
    Task<ServiceResponse> UpdateMovie(Guid id, CreateMovieRequest data);
    Task<ServiceResponse> DeleteMovie(Guid id);
}