using MovieApp.ServiceModels.MovieServiceModels;

namespace MovieApp.Services.Interfaces;

public interface IMovieService
{
    MovieDto GetById(int id);
    IEnumerable<MovieDto> GetAllMovies();
    IEnumerable<MovieDto> FilterByYear(int year);
    IEnumerable<MovieDto> FilterByGenre(string genre);
    void AddMovie(MovieDto entity);
    void UpdateMovie(int id, UpdateMovieDto entity);
    void DeleteMovie(int id);
}
