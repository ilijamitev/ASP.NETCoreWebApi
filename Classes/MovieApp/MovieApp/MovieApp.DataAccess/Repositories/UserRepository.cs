using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess.Data;
using MovieApp.DataAccess.Repositories.Interfaces;
using MovieApp.Domain.Models;

namespace MovieApp.DataAccess.Repositories;

public class UserRepository : IRepository<User>
{
    //private readonly DbSet<User> _users;
    private readonly MovieAppDbContext _context;
    public UserRepository(MovieAppDbContext context)
    {
        //_users = context.Set<User>();
        _context = context;
    }

    //public IQueryable<User> Query { get { return _users; } }

    public void Delete(int id)
    {
        var user = _context.Users.SingleOrDefault(x => x.Id == id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public IEnumerable<User> FilterBy(Func<User, bool> filter)
    {
        return _context.Users.Where(filter);
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id)
    {
        return _context.Users.SingleOrDefault(x => x.Id == id);
    }

    public void Insert(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
    }

    public void Update(User entity)
    {
        _context.Users.Update(entity);
        _context.SaveChanges();
    }
}
