using Dapper;
using MovieApp.DataAccess.Repositories.Interfaces;
using MovieApp.Domain.Enums;
using MovieApp.Domain.Models;
using System.Data.SqlClient;

namespace MovieApp.DataAccess.Repositories;
public class MovieDapperRepository : IRepository<Movie>
{
    // NIKAKO
    private readonly string _connString = "Server=.;Database=MovieApp_DB;Trusted_Connection=True";

    public MovieDapperRepository()
    {
    }

    public IEnumerable<Movie> GetAll()
    {
        //string connString = _confiq.GetConnectionString("MovieAppDbConnection");
        using SqlConnection connection = new(_connString);
        var sqlQuery = @"SELECT * FROM dbo.Movies";
        connection.Open();
        var movies = connection.Query<Movie>(sqlQuery);
        return movies;
    }

    public Movie GetById(int id)
    {
        using SqlConnection connection = new(_connString);
        connection.Open();
        var sqlQuery = $@"SELECT * FROM dbo.Movies WHERE Id = @Id";
        var movie = connection.Query<Movie>(sqlQuery, new { Id = id }).SingleOrDefault();
        return movie;
    }

    public IEnumerable<Movie> FilterBy(Func<Movie, bool> filter)
    {
        throw new NotImplementedException();
    }

    public void Insert(Movie entity)
    {
        using SqlConnection connection = new(_connString);
        connection.Open();
        var sqlQuery = $@"INSERT INTO dbo.Movies (Title,Year,Description,Genre)" +
            "VALUES(@title,@year,@description,@genre)";
        connection.Query<Movie>(
            sqlQuery,
            new { title = entity.Title, year = entity.Year, description = entity.Description, genre = entity.Genre });
    }

    public void Update(Movie entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        using SqlConnection connection = new(_connString);
        connection.Open();
        var sqlQuery = $@"DELETE FROM dbo.Movies WHERE Id = @Id";
        var movie = connection.Query<Movie>(sqlQuery, new { Id = id });
    }

}
