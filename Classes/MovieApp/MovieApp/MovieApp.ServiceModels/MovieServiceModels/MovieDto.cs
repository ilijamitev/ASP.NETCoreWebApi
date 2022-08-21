using System.ComponentModel.DataAnnotations;

namespace MovieApp.ServiceModels.MovieServiceModels;

public class MovieDto
{
    [Required(ErrorMessage = "Please enter Title")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "Please enter Description")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Please enter Year")]
    [Range(1950, 2022, ErrorMessage = "Please select year between 1950 and 2022")]
    public int? Year { get; set; }
    [Required(ErrorMessage = "Please enter Genre")]
    public string? Genre { get; set; }

}