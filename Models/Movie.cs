using MovieWatchlist.Contracts.Movie;
using MovieWatchlist.ServiceErrors;
using ErrorOr;

namespace MovieWatchlist.Models;

public class Movie
{
    /*
    * Validations
    */
    public const int MinTitleLength = 3;
    public const int MaxTitleLength = 50;
    public const int MinOverviewLength = 10;
    public const int MaxOverviewLength = 150;
    public const int MaxGenresgth = 3;

    /*
    * Fields
    */
    public Guid Id { get; }
    public string Title { get; }
    public string Overview { get; }
    public List<string> Genres { get; }
    public DateTime CreationDate { get; }
    public DateTime LastUpdated { get; }

    private Movie(
        Guid id,
        string title,
        string overview,
        List<string> genres,
        DateTime creationDate,
        DateTime lastUpdated
        )
    {
        Id = id;
        Title = title;
        Overview = overview;
        Genres = genres;
        CreationDate = creationDate;
        LastUpdated = lastUpdated;
    }

    public static ErrorOr<Movie> Create(
        string title,
        string overview,
        List<string> genres,
        DateTime creationDate,
        DateTime lastUpdated
    )
    {
        List<Error> errors = new();

        if (title.Length is < MinTitleLength or > MaxTitleLength)
        {
            errors.Add(Errors.Movie.InvalidTitle);
        }

        if (overview.Length is < MinOverviewLength or > MaxOverviewLength)
        {
            errors.Add(Errors.Movie.InvalidOverview);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        // enforce invariants
        return new Movie(
            // id ?? Guid.NewGuid(),
            Guid.NewGuid(),
            title,
            overview,
            genres,
            creationDate,
            lastUpdated
        );
    }

    public static ErrorOr<Movie> From(CreateMovieRequest request)
    {
        return Create(
            request.Title,
            request.Overview,
            request.Genres,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

    public static ErrorOr<Movie> From(Guid id, CreateMovieRequest request)
    {
        return Create(
            request.Title,
            request.Overview,
            request.Genres,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
