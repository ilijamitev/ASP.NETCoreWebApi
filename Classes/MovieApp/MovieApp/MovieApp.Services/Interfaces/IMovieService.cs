using MovieApp.ServiceModels.MovieServiceModels;
using MovieApp.ServiceModels.MovieServiceModels.Enums;

namespace MovieApp.Services.Interfaces;

public interface IMovieService
{
    MovieDto GetById(int id);
    IEnumerable<MovieDto> GetAllMovies();
    IEnumerable<MovieDto> OrderMoviesBy(MovieOrderBy orderBy);
    IEnumerable<MovieDto> FilterByYear(int year);
    IEnumerable<MovieDto> FilterByGenre(string genre);
    void AddMovie(CreateMovieDto entity);
    void UpdateMovie(UpdateMovieDto entity);
    void DeleteMovie(int id);
}
