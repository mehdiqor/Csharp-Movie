
using Dto.Movie;

namespace MovieWatchlist.Models;

public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
    // public List<string> Genres { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdated { get; set; }

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

    public static Movie Create(
      string title,
      string overview,
      // List<string> genres,
      DateTime creationDate,
      DateTime lastUpdated,
      Guid id
    )
    {
        return new Movie(
          id,
          title,
          overview,
          // genres,
          creationDate,
          lastUpdated
      );
    }

    public static Movie CreateFrom(CreateMovieRequest request)
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

    public static Movie UpdateFrom(Guid id, CreateMovieRequest request)
    {
        return Create(
            request.Title,
            request.Overview,
            // request.Genres,
            // fix creation date
            DateTime.UtcNow,
            DateTime.UtcNow,
            id
        );
    }
}

