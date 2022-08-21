﻿namespace MovieApp.Domain.Models;

public class UserMovie : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}
