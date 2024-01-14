using MovieWatchlist.Exceptions;
using MovieWatchlist.Validators;
using MovieWatchlist.Dtos;
using MovieWatchlist.Services;

namespace MovieWatchlist.Managers;

public class MovieManager : IMovieManager
{
    private readonly IMovieService _movieService;
    private readonly ILogger<MovieService> _logger;

    public MovieManager(
        IMovieService movieService,
        ILogger<MovieService> logger
    )
    {
        _movieService = movieService;
        _logger = logger;
    }

    public async Task<ServiceResponse> CreateMovie(CreateMovieRequest data)
    {
        var validator = new CreateMovieValidator();
        var validationResult = await validator.ValidateAsync(data);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

            _logger.LogWarning("Invalid input for create movie");
            throw new CustomValidationException(errors);
        }

        _logger.LogInformation("Input validated for create movie");
        return await _movieService.CreateMovie(data);
    }

    public async Task<ServiceResponse> GetOneMovie(Guid id)
    {
        var validator = new GuidIdValidator();
        var validationResult = await validator.ValidateAsync(id);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

            _logger.LogWarning("Invalid input for create movie");
            throw new CustomValidationException(errors);
        }

        _logger.LogInformation("Input validated for get one movie");
        return await _movieService.GetOneMovie(id);
    }

    public async Task<ServiceResponse> UpdateMovie(Guid id, CreateMovieRequest data)
    {
        var validator = new CreateMovieValidator();
        var validationResult = validator.Validate(data);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

            _logger.LogWarning("Invalid input for update movie");
            throw new CustomValidationException(errors);
        }

        _logger.LogInformation("Input validated for update movie");
        return await _movieService.UpdateMovie(id, data);
    }

    public async Task<ServiceResponse> DeleteMovie(Guid id)
    {
        return await _movieService.DeleteMovie(id);
    }
}