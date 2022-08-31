using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.DataAccess.Data;
using MovieApp.DataAccess.Repositories;
using MovieApp.DataAccess.Repositories.Interfaces;
using MovieApp.Domain.Models;
using MovieApp.Helpers.Validations;
using MovieApp.Mappers;
using MovieApp.ServiceModels.MovieServiceModels;
using MovieApp.Services.Interfaces;
using MovieApp.Services.MovieService;

namespace MovieApp.Helpers.DependencyInjection;

public static class DependencyInjectionHelper
{
    public static IServiceCollection InjectDbContext(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<MovieAppDbContext>(options => options.UseSqlServer(connectionString));
    }

    public static IServiceCollection InjectRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRepository<User>, UserRepository>();
        //services.AddTransient<IRepository<Movie>, MovieRepository>();
        services.AddTransient<IRepository<Movie>, MovieDapperRepository>();
        return services;
    }

    public static IServiceCollection InjectServices(this IServiceCollection services)
    {
        services.AddTransient<IMovieService, MovieService>();
        return services;
    }

    public static IServiceCollection InjectAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MovieProfile));
        services.AddAutoMapper(typeof(UserProfile));
        return services;
    }

    public static IServiceCollection InjectFluentValidator(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateMovieDto>, CreateMovieValidator>();
        return services;
    }

}
