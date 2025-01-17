﻿using MovieApp.Domain.Enums;

namespace MovieApp.Domain.Models;

public class Movie : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public Genre Genre { get; set; }
    public List<UserMovie> UserMovies { get; set; } = new List<UserMovie>();

}
