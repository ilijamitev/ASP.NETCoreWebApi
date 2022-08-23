using System;
using System.Collections.Generic;

namespace Class06.EF.WebApi.Domain
{
    public partial class Movie
    {
        public Movie()
        {
            UsersMovies = new HashSet<UsersMovie>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public int Genre { get; set; }

        public virtual ICollection<UsersMovie> UsersMovies { get; set; }
    }
}
