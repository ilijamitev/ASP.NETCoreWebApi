using Microsoft.AspNetCore.Mvc;
using MovieApp.ServiceModels.MovieServiceModels;
using MovieApp.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieApp.WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;
    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<MovieDto>> GetAllMovies()
    {
        try
        {
            return Ok(_movieService.GetAllMovies());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<MovieDto> GetMovieById(int id)
    {
        try
        {
            return _movieService.GetById(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("create")]
    public ActionResult AddMovie([FromBody] MovieDto movie)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _movieService.AddMovie(movie);
                return Ok();
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/<MovieController>/5
    [HttpPut("update/{id}")]
    public ActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
    {
        try
        {
            _movieService.UpdateMovie(movieDto);
            return
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/<MovieController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
