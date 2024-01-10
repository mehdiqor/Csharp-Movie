using Dto.Movie;

namespace Services.MovieWatchlist;

public interface IMovieService
{
    Task<CreateMovieResponse> CreateMovie(CreateMovieRequest data);

    Task<GetMovieResponse> GetOneMovie(Guid id);

    Task<string> UpdateMovie(Guid id, CreateMovieRequest data);

    Task DeleteMovie(Guid id);
}