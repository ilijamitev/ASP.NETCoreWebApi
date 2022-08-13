using Class02.WebApi.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class02.WebApi.Demo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly List<Movie> _movies = new List<Movie>()
        {
            new Movie
            {
                Id=1,
                Title="James Bond",
                Year = 1956,
                Genre = Genre.Action,
                Rating = 1
            },
            new Movie
            {
                Id=2,
                Title="Red Notice",
                Year = 2020,
                Genre = Genre.Comedy,
                Rating = 5
            },
            new Movie
            {
                Id=3,
                Title="Star Wars",
                Year = 1996,
                Genre = Genre.SciFi,
                Rating = 10
            },
        };

        [HttpGet("{id}")]
        public ActionResult GetMovieById(int id)
        {
            if (id < 1) return BadRequest();
            var movie = _movies[id];
            if (movie is null) return BadRequest();
            return Ok(movie);
        }

        [HttpGet("name/{name}")]
        public ActionResult GetMovieByName(string name)
        {
            var movie = _movies.Where(x => x.Title.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            if (movie is null) return BadRequest();
            return Ok(movie);
        }

        [HttpGet("yearFrom/{from}/yearTo/{to}")]
        public ActionResult<IEnumerable<Movie>> GetMoviesByYear(int from, int to)
        {
            var movies = _movies.Where(x => x.Year >= from && x.Year <= to);
            if (movies is null) return BadRequest();
            return Ok(movies);
        }

        [HttpGet("genre/{genre}/year/{year}")]
        public ActionResult<IEnumerable<Movie>> GetMoviesByGenreAndYear(Genre genre, int year)
        {
            var movies = _movies.Where(x => x.Genre == genre && x.Year == year);
            if (movies is null) return BadRequest();
            return Ok(movies);
        }

        [HttpGet("ratingFrom/{from}/ratingTo/{to}")]
        public ActionResult<IEnumerable<Movie>> GetMoviesByGenreAndYear(int from, int to)
        {
            var movies = _movies.Where(x => x.Rating >= from && x.Rating <= to);
            if (movies is null) return BadRequest();
            return Ok(movies);
        }
    }
}
