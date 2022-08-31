using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Models;

namespace MovieApp.DataAccess.Data;

public class MovieAppDbContext : DbContext
{
    public MovieAppDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserMovie> UsersMovies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // DA PROBAM BEZ OVA
        modelBuilder.Entity<UserMovie>()
            .HasKey(x => new { x.MovieId, x.UserId }); //setting two primary keys

        modelBuilder.Entity<UserMovie>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserMovies)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<UserMovie>()
            .HasOne(x => x.Movie)
            .WithMany(x => x.UserMovies)
            .HasForeignKey(x => x.MovieId);

        DataSeed.InsertDataInDb(modelBuilder);
    }
}
