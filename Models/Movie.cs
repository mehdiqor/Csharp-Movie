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
    // public const int MaxGenresgth = 3;

    /*
    * Fields
    */
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Overview { get; set; }
    // public List<string> Genres { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdated { get; set; }

    private Movie()
    {
    }

    private Movie(
     Guid id,
     string title,
     string overview,
    // List<string> genres,
     DateTime creationDate,
     DateTime lastUpdated
     )
    {
        Id = id;
        Title = title;
        Overview = overview;
        // Genres = genres;
        CreationDate = creationDate;
        LastUpdated = lastUpdated;
    }

    public static ErrorOr<Movie> Create(
      string title,
      string overview,
    // List<string> genres,
      DateTime creationDate,
      DateTime lastUpdated,
      Guid id
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

        return new Movie(
          id,
          title,
          overview,
        // genres,
          creationDate,
          lastUpdated
      );
    }

    public static ErrorOr<Movie> CreateFrom(CreateMovieRequest request)
    {
        return Create(
            request.Title,
            request.Overview,
            // request.Genres,
            DateTime.UtcNow,
            DateTime.UtcNow,
            Guid.NewGuid()
        );
    }

    public static ErrorOr<Movie> UpdateFrom(Guid id, CreateMovieRequest request)
    {
        return Create(
            request.Title,
            request.Overview,
            // request.Genres,
            DateTime.UtcNow,
            DateTime.UtcNow,
            id
        );
    }
}
