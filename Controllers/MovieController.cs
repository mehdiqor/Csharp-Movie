using MovieWatchlist.RequestCounter;
using Microsoft.AspNetCore.Mvc;
using Middlewares;
using Dto.Movie;

namespace MovieWatchlist.Controllers;

[JwtAuthorize]
public class MoviesController : ApiController
{
    private readonly IRequestCounter _requestCounter;
    private readonly MovieManager _movieManager;

    public MoviesController(
        IRequestCounter requestCounter,
        MovieManager movieManager
        )
    {
        _requestCounter = requestCounter;
        _movieManager = movieManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie(CreateMovieRequest request)
    {
        _requestCounter.Increment();
        // if you want to get the number of requests:
        // int requestCount = _requestCounter.Count;

        var result = await _movieManager.CreateMovie(request);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOneMovie(Guid id)
    {
        _requestCounter.Increment();

        var result = await _movieManager.GetOneMovie(id);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateMovie(Guid id, CreateMovieRequest request)
    {
        _requestCounter.Increment();

        var result = await _movieManager.UpdateMovie(id, request);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteMovie(Guid id)
    {
        _requestCounter.Increment();

        await _movieManager.DeleteMovie(id);
        return NoContent();
    }
}
