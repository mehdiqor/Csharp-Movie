
using Repositories.MovieWatchlist;
using MovieWatchlist.Models;
using Dto.Movie;

namespace Services.MovieWatchlist;

public class MovieService : IMovieService
{

    private readonly IMovieRepository _movieRepository;
    private readonly ILogger<MovieService> _logger;

    public MovieService(
        IMovieRepository movieRepository,
        ILogger<MovieService> logger
    )
    {
        _movieRepository = movieRepository;
        _logger = logger;
    }

    public async Task<CreateMovieResponse> CreateMovie(CreateMovieRequest data)
    {
        try
        {
            var movie = Movie.CreateFrom(data);
            await _movieRepository.CreateMovie(movie);

            _logger.LogInformation("User signed up successfully");

            return new CreateMovieResponse(
                movie.Id.ToString(),
                movie.Title,
                movie.Overview,
                movie.CreationDate,
                movie.LastUpdated
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting a movie");
            throw;
        }
    }

    public async Task<GetMovieResponse> GetOneMovie(Guid id)
    {
        try
        {
            var movie = await _movieRepository.GetOneMovie(id);

            if (movie == null)
            {
                _logger.LogWarning($"Movie not found for id: {id}");
                throw new CustomNotFoundException("Movie NotFound");
            }

            _logger.LogInformation("Movie retrieved successfully");

            return new GetMovieResponse(
                movie.Id.ToString(),
                movie.Title,
                movie.Overview,
                movie.CreationDate,
                movie.LastUpdated
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting a movie");
            throw;
        }
    }

    public async Task<string> UpdateMovie(Guid id, CreateMovieRequest data)
    {
        try
        {
            var extMovie = await _movieRepository.GetOneMovie(id);

            if (extMovie == null)
            {
                _logger.LogWarning($"Movie not found for id: {id}");
                throw new CustomNotFoundException("Movie NotFound");
            }

            var movie = Movie.UpdateFrom(id, data);
            await _movieRepository.UpdateMovie(movie);

            return "Movie updated successfull";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating a movie");
            throw;
        }
    }

    public async Task DeleteMovie(Guid id)
    {
        try
        {
            var extMovie = await _movieRepository.GetOneMovie(id);

            if (extMovie == null)
            {
                _logger.LogWarning($"Movie not found for id: {id}");
                throw new CustomNotFoundException("Movie NotFound");
            }

            await _movieRepository.DeleteMovie(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting a movie");
            throw;
        }
    }
}