using Microsoft.Extensions.DependencyInjection;
using Notes.Services;
using Notes.Services.Interfaces;

namespace Notes.DependencyInjection
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
