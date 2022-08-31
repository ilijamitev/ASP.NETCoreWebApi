using MovieApp.Domain;

namespace MovieApp.DataAccess.Repositories.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    //public IQueryable<T> Query { get; }
    T GetById(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> FilterBy(Func<T, bool> filter);
    void Insert(T entity);
    void Update(T entity);
    void Delete(int id);
}
