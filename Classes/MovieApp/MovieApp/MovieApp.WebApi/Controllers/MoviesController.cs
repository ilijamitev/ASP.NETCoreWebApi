using Microsoft.AspNetCore.Mvc;
using MovieApp.ServiceModels.MovieServiceModels;
using MovieApp.Services.Interfaces;

namespace MovieApp.WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;
    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<MovieDto>> GetAllMovies([FromQuery] string? orderBy = null)
    {
        try
        {
            if (orderBy != null)
            {
                return Ok(_movieService.OrderMoviesBy(orderBy));
            }
            return Ok(_movieService.GetAllMovies());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("all/filterByGenre/{genre}")]
    public ActionResult<IEnumerable<MovieDto>> FilterMoviesByGenre(string genre = "Comedy")
    {
        try
        {
            return Ok(_movieService.FilterByGenre(genre));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("all/filterByYear/{year}")]
    public ActionResult<IEnumerable<MovieDto>> FilterMoviesByYear(int year = 2022)
    {
        try
        {
            return Ok(_movieService.FilterByYear(year));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("movie/{id}")]
    public ActionResult<MovieDto> GetMovieById([FromRoute] int id)
    {
        try
        {
            return Ok(_movieService.GetById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("add")]
    public ActionResult AddMovie(CreateMovieDto movieDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                //_createMovieValidator.ValidateAndThrow(movieDto);          // DALI TUKA ILI VO SERVISITE
                _movieService.AddMovie(movieDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //[HttpPost("add")]
    //public ActionResult AddMovie(string title, string description, string genre, int year)
    //{
    //    try
    //    {
    //        var movieDto = new CreateMovieDto
    //        {
    //            Description = description,
    //            Year = year,
    //            Genre = genre,
    //            Title = title,
    //        };
    //        _createMovieValidator.ValidateAndThrow(movieDto);
    //        _movieService.AddMovie(movieDto);
    //        return StatusCode(StatusCodes.Status201Created);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}

    [HttpPut("movie/{id}/update")]
    public ActionResult UpdateMovie(int id, string title, string description, int year, string genre)
    {
        try
        {
            var updateMovieDto = new UpdateMovieDto
            {
                Id = id,
                Title = title,
                Description = description,
                Year = year,
                Genre = genre,
            };
            _movieService.UpdateMovie(updateMovieDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        try
        {
            _movieService.DeleteMovie(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, $"ERROR MESSAGE: {ex.Message}\nERROR SOURCE: {ex.Source}");
        }
    }
}
