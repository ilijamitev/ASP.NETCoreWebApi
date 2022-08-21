using AutoMapper;
using MovieApp.DataAccess.Repositories.Interfaces;
using MovieApp.Domain.Enums;
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

    public void AddMovie(MovieDto entity)
    {
        var movie = _mapper.Map<Movie>(entity);
        _movieRepository.Insert(movie);
    }

    public void DeleteMovie(int id)
    {
        var movie = _movieRepository.GetById(id);
        ArgumentNullException.ThrowIfNull(movie);
        _movieRepository.Delete(movie);
    }

    public IEnumerable<MovieDto> FilterByGenre(string genre)
    {
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

    public IEnumerable<MovieDto> GetAllMovies()
    {
        var movies = _movieRepository.GetAll().Select(_mapper.Map<Movie, MovieDto>);
        return movies;
    }

    public MovieDto GetById(int id)
    {
        var movie = _movieRepository.GetById(id);
        ArgumentNullException.ThrowIfNull(movie);
        var movieDto = _mapper.Map<MovieDto>(movie);
        return movieDto;
    }

    public void UpdateMovie(int id, UpdateMovieDto entity)
    {
        var movie = _movieRepository.GetById(id);
        var movieDto = _mapper.Map<MovieDto>(movie);
        var movies = _mapper.Map<UpdateMovieDto>(entity);
        //var movie = _mapper.Map<Movie>(entity);
        _movieRepository.Update(movie);
    }
}
