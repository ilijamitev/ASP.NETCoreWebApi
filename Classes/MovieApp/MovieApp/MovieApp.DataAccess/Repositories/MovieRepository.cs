using MovieApp.DataAccess.Data;
using MovieApp.DataAccess.Repositories.Interfaces;
using MovieApp.Domain.Models;

namespace MovieApp.DataAccess.Repositories;

public class MovieRepository : IRepository<Movie>
{
    private readonly MovieAppDbContext _context;
    public MovieRepository(MovieAppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Movie> GetAll()
    {
        return _context.Movies;
    }

    public Movie GetById(int id)
    {
        return _context.Movies.SingleOrDefault(x => x.Id == id);
    }

    public IEnumerable<Movie> FilterBy(Func<Movie, bool> filter)
    {
        return _context.Movies.Where(filter);
    }

    public void Insert(Movie entity)
    {
        _context.Movies.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Movie entity)
    {
        _context.ChangeTracker.Clear();
        _context.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(Movie entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }
}
