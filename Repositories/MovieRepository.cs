using Microsoft.EntityFrameworkCore;
using MovieWatchlist.Models;
using DatabaseConnection;
using Dto.Movie;

namespace Repositories.MovieWatchlist;

public class MovieRepository : IMovieRepository
{
    private readonly MovieDbContext _context;
    private readonly ILogger<MovieRepository> _logger;

    public MovieRepository(MovieDbContext context, ILogger<MovieRepository> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task CreateMovie(Movie data)
    {
        try
        {
            _context.Movies?.Add(data);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "An error occurred while saving movie in database");
            throw;
        }
    }

    public async Task<GetMovieResponse> GetOneMovie(Guid id)
    {

        var movie = await _context.Movies.FindAsync(id);
        if (movie != null)
        {
            return new GetMovieResponse(
                movie.Id.ToString(),
                movie.Title,
                movie.Overview,
                movie.CreationDate,
                movie.LastUpdated
            );
        }
        else
        {
            _logger.LogWarning($"No movie found with id: {id}");
            return null;
        }
    }

    public async Task UpdateMovie(Movie data)
    {
        try
        {
            _context.Movies.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "An error occurred while updating a movie");
            throw;
        }
    }

    public async Task DeleteMovie(Guid id)
    {
        try
        {
            var movieToDelete = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "An error occurred while deleting a movie");
            throw;
        }
    }
}
