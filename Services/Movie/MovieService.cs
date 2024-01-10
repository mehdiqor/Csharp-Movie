using MovieWatchlist.DatabaseConnection;
using Microsoft.EntityFrameworkCore;
using MovieWatchlist.ServiceErrors;
using MovieWatchlist.Models;
using ErrorOr;

namespace MovieWatchlist.Services.Movies;

public class MovieService : IMovieService
{
    private readonly MovieDbContext _context;

    public MovieService(MovieDbContext context)
    {
        _context = context;
    }

    public ErrorOr<Created> CreateMovie(Movie movie)
    {
        _context.Movies?.Add(movie);
        _context.SaveChanges();

        return Result.Created;
    }

    public ErrorOr<Movie> GetMovie(Guid id)
    {
        var movie = _context.Movies?.Find(id);

        if (movie == null)
        {
            return Errors.Movie.NotFound;
        }

        return movie;
    }

    public ErrorOr<Updated> UpsertMovie(Movie movie)
    {
        var existingMovie = _context.Movies?.Find(movie.Id);

        if (existingMovie == null)
        {
            return Errors.Movie.NotFound;
        }

        _context.Entry(existingMovie).CurrentValues.SetValues(movie);
        _context.Entry(existingMovie).State = EntityState.Modified;
        _context.SaveChanges();

        return Result.Updated;
    }

    public ErrorOr<Deleted> DeleteMovie(Guid id)
    {
        var movie = _context.Movies?.Find(id);

        if (movie != null)
        {
            _context.Movies?.Remove(movie);
            _context.SaveChanges();
            return Result.Deleted;
        }

        return Errors.Movie.NotFound;
    }

}