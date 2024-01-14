using MovieWatchlist.Repositories;
using MovieWatchlist.Exceptions;
using MovieWatchlist.Models;
using MovieWatchlist.Dtos;

namespace MovieWatchlist.Services;

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

    public async Task<ServiceResponse> CreateMovie(CreateMovieRequest data)
    {
        try
        {
            var movie = Movie.CreateFrom(data);
            await _movieRepository.CreateMovie(movie);

            _logger.LogInformation("User signed up successfully");

            var response = new CreateMovieResponse(
                movie.Id.ToString(),
                movie.Title,
                movie.Overview,
                movie.CreationDate,
                movie.LastUpdated
            );

            return new ServiceResponse(
                Message: "OK",
                Data: response
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating a movie");
            throw;
        }
    }

    public async Task<ServiceResponse> GetOneMovie(Guid id)
    {
        try
        {
            var movie = await _movieRepository.GetOneMovie(id);

            if (movie == null)
            {
                _logger.LogWarning("Movie not found for id: {id}", id);
                throw new CustomNotFoundException("Movie NotFound");
            }

            _logger.LogInformation("Movie retrieved successfully");

            var response = new GetMovieResponse(
                movie.Id.ToString(),
                movie.Title,
                movie.Overview,
                movie.CreationDate,
                movie.LastUpdated
            );

            return new ServiceResponse(
                Message: "OK",
                Data: response
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting a movie");
            throw;
        }
    }

    public async Task<ServiceResponse> UpdateMovie(Guid id, CreateMovieRequest data)
    {
        try
        {
            var extMovie = await _movieRepository.GetOneMovie(id);

            if (extMovie == null)
            {
                _logger.LogWarning("Movie not found for id: {id}", id);
                throw new CustomNotFoundException("Movie NotFound");
            }

            var updateData = new UpdateMovieFrom(
                Title: data.Title,
                Overview: data.Overview,
                CreationDate: extMovie.CreationDate
            );

            var movie = Movie.UpdateFrom(id, updateData);

            await _movieRepository.UpdateMovie(movie);

            return new ServiceResponse(
                Message: "UPDATED",
                Data: new { }
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating a movie");
            throw;
        }
    }

    public async Task<ServiceResponse> DeleteMovie(Guid id)
    {
        try
        {
            var extMovie = await _movieRepository.GetOneMovie(id);

            if (extMovie == null)
            {
                _logger.LogWarning("Movie not found for id: {id}", id);
                throw new CustomNotFoundException("Movie NotFound");
            }

            await _movieRepository.DeleteMovie(id);

            return new ServiceResponse(
                Message: "DELETED",
                Data: new { }
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting a movie");
            throw;
        }
    }
}