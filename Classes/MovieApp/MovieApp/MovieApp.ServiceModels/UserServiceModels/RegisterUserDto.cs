﻿namespace MovieApp.ServiceModels.UserServiceModels;

public class RegisterUserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
