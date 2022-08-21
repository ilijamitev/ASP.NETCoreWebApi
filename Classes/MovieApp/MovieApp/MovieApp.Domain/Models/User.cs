using MovieApp.Domain.Enums;

namespace MovieApp.Domain.Models;

public class User : BaseEntity
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Genre FavouriteGenre { get; set; }
    public List<UserMovie> UserMovies { get; set; } = new List<UserMovie>();

}
