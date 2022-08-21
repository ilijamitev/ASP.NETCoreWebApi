using AutoMapper;
using MovieApp.DataAccess.Repositories.Interfaces;
using MovieApp.Domain.Models;
using MovieApp.ServiceModels.MovieServiceModels;
using MovieApp.Services.Interfaces;

namespace MovieApp.Services.MovieService;

public class MovieService : IMovieService
{
    private readonly IRepository<Movie> _movieRepository;
    private readonly IMapper _mapper;
    public MovieService(IRepository<Movie> movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public IEnumerable<MovieDto> GetAllMovies()
    {
        var movies = _movieRepository.GetAll().Select(_mapper.Map<Movie, MovieDto>);
        return movies;
    }

    public IEnumerable<MovieDto> OrderMoviesBy(string orderBy)
    {
        var movies = _movieRepository.GetAll().Select(_mapper.Map<Movie, MovieDto>);
        return orderBy switch
        {
            "title_asc" => movies.OrderBy(x => x.Title),
            "title_desc" => movies.OrderByDescending(x => x.Title),
            "year_asc" => movies.OrderBy(x => x.Year),
            "year_desc" => movies.OrderByDescending(x => x.Year),
            "genre_asc" => movies.OrderBy(x => x.Genre),
            "genre_desc" => movies.OrderByDescending(x => x.Genre),
            _ => throw new NotImplementedException($"No ordering by {orderBy} is available!"),
        };
    }

    public MovieDto GetById(int id)
    {
        var movie = _movieRepository.GetById(id);
        ArgumentNullException.ThrowIfNull(movie);
        var movieDto = _mapper.Map<MovieDto>(movie);
        return movieDto;
    }

    public void AddMovie(CreateMovieDto entity)
    {
        var movie = _mapper.Map<Movie>(entity);
        _movieRepository.Insert(movie);
    }

    public IEnumerable<MovieDto> FilterByGenre(string genre)
    {
        // kako da se napravi da ne gi zima site za da proveruva dali ima nesto .... tuku direktno da proveri
        var movies = _movieRepository.FilterBy(x => x.Genre.ToString() == genre).Select(_mapper.Map<Movie, MovieDto>).OrderBy(x => x.Title);
        if (!movies.Any())
        {
            throw new Exception($"Genre with name {genre} does not exist!");
        }
        return movies;
    }

    public IEnumerable<MovieDto> FilterByYear(int year)
    {
        var movies = _movieRepository.FilterBy(x => x.Year == year).Select(_mapper.Map<Movie, MovieDto>).OrderBy(x => x.Year);
        if (!movies.Any())
        {
            throw new Exception($"No movie was found from year {year}!");
        }
        return movies;
    }

    public void UpdateMovie(UpdateMovieDto entity)
    {
        var movie = _movieRepository.GetById(entity.Id);
        ArgumentNullException.ThrowIfNull(movie);
        movie = _mapper.Map<Movie>(entity);
        _movieRepository.Update(movie);
    }

    public void DeleteMovie(int id)
    {
        var movie = _movieRepository.GetById(id);
        ArgumentNullException.ThrowIfNull(movie);
        _movieRepository.Delete(movie);
    }

}
