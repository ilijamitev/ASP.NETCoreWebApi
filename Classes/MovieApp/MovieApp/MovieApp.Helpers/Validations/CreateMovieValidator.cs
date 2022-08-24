using FluentValidation;
using MovieApp.ServiceModels.MovieServiceModels;

namespace MovieApp.Helpers.Validations;

public class CreateMovieValidator : AbstractValidator<CreateMovieDto>
{
    public CreateMovieValidator()
    {
        RuleFor(x => x.Year).NotNull().InclusiveBetween(1950, 2022);
        RuleFor(x => x.Title).NotNull().Length(10, 100);
        RuleFor(x => x.Genre).NotNull();
        RuleFor(x => x.Description).NotNull().MaximumLength(300);
    }
}
