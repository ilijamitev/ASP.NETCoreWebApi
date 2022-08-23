using System;
using System.Collections.Generic;

namespace Class06.EF.DbFirst.DataAccess.Domain
{
    public partial class User
    {
        public User()
        {
            UsersMovies = new HashSet<UsersMovie>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int FavouriteGenre { get; set; }

        public virtual ICollection<UsersMovie> UsersMovies { get; set; }
    }
}
