using MovieWatchlist.Services.Movies;
using MovieWatchlist.Contracts.Movie;
using Microsoft.AspNetCore.Mvc;
using MovieWatchlist.Models;
using ErrorOr;

namespace MovieWatchlist.Controllers;

public class MoviesController : ApiController
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    /*
    * Create movie
    */
    [HttpPost]
    public IActionResult CreateMovie(CreateMovieRequest request)
    {
        ErrorOr<Movie> requestToMovieResult = Movie.From(request);

        if (requestToMovieResult.IsError)
        {
            return Problem(requestToMovieResult.Errors);
        }

        var movie = requestToMovieResult.Value;

        // TODO: save movie in database
        ErrorOr<Created> createMovieResult = _movieService.CreateMovie(movie);

        return createMovieResult.Match(
            created => CreatedAsGetMovie(movie),
            errors => Problem(errors)
        );
    }

    /*
    * Get one movie
    */
    [HttpGet("{id:guid}")]
    public IActionResult GetMovie(Guid id)
    {
        ErrorOr<Movie> getMovieResult = _movieService.GetMovie(id);

        return getMovieResult.Match(
            movie => Ok(MapMovieResponse(movie)),
            errors => Problem(errors)
        );
    }

    /*
    * Update one movie
    */
    [HttpPut("{id:guid}")]
    public IActionResult UpsertMovie(Guid id, CreateMovieRequest request)
    {
        ErrorOr<Movie> requestToMovieResult = Movie.From(id, request);

        if (requestToMovieResult.IsError)
        {
            return Problem(requestToMovieResult.Errors);
        }

        var movie = requestToMovieResult.Value;

        ErrorOr<UpsertedMovie> upsertMovieResult = _movieService.UpsertMovie(movie);

        return upsertMovieResult.Match(
            upserted => upserted.IsNewCreated ? CreatedAsGetMovie(movie) : NoContent(),
            errors => Problem(errors)
        );
    }

    /*
    * Delete one movie
    */
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMovie(Guid id)
    {
        ErrorOr<Deleted> deleteMovieResult = _movieService.DeleteMovie(id);

        return deleteMovieResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    /*
    * Static functions
    */
    private static MovieResponse MapMovieResponse(Movie movie)
    {
        return new MovieResponse(
            movie.Id,
            movie.Title,
            movie.Overview,
            movie.Genres,
            movie.CreationDate,
            movie.LastUpdated
        );
    }

    private CreatedAtActionResult CreatedAsGetMovie(Movie movie)
    {
        return CreatedAtAction(
            actionName: nameof(GetMovie),
            routeValues: new { id = movie.Id },
            value: MapMovieResponse(movie)
        );
    }
}
