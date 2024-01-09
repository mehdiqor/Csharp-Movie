using Microsoft.AspNetCore.Mvc;

namespace MovieWatchlist.Controllers;

public class ErrorsController : ControllerBase
{
    // [Route("/error")]
    [HttpGet("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}