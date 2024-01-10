using Services.MovieWatchlist;
using Dto.Movie;

public class MovieManager
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

    public async Task<CreateMovieResponse> CreateMovie(CreateMovieRequest data)
    {
        var validator = new CreateMovieValidator();
        var validationResult = validator.Validate(data);

        if (!validationResult.IsValid)
        {
            List<string> errors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(error.ErrorMessage);
            }

            _logger.LogWarning("Invalid input for create movie");
            throw new CustomValidationException(errors);
        }

        _logger.LogInformation("Input validated for create movie");
        return await _movieService.CreateMovie(data);
    }

    public async Task<GetMovieResponse> GetOneMovie(Guid id)
    {
        return await _movieService.GetOneMovie(id);
    }

    public async Task<string> UpdateMovie(Guid id, CreateMovieRequest data)
    {
        var validator = new CreateMovieValidator();
        var validationResult = validator.Validate(data);

        if (!validationResult.IsValid)
        {
            List<string> errors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(error.ErrorMessage);
            }

            _logger.LogWarning("Invalid input for update movie");
            throw new CustomValidationException(errors);
        }

        _logger.LogInformation("Input validated for update movie");
        return await _movieService.UpdateMovie(id, data);
    }

    public async Task DeleteMovie(Guid id)
    {
        await _movieService.DeleteMovie(id);
    }
}
