using System.ComponentModel.DataAnnotations;
using MovieWatchlist.Dtos;

namespace MovieWatchlist.Models;

public class Movie
{
    public Guid Id { get; set; }

    [MaxLength(15)] public string Title { get; set; }

    [MaxLength(50)] public string Overview { get; set; }

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

    private static Movie Create(
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
        var now = DateTime.UtcNow;

        return Create(
            request.Title,
            request.Overview,
            // request.Genres,
            now,
            now,
            Guid.NewGuid()
        );
    }

    public static Movie UpdateFrom(Guid id, UpdateMovieFrom data)
    {
        return Create(
            data.Title,
            data.Overview,
            // data.Genres,
            data.CreationDate,
            DateTime.UtcNow,
            id
        );
    }
}