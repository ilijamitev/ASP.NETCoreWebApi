using Microsoft.Extensions.DependencyInjection;
using Notes.DataAccess;
using Notes.DataAccess.Repositories;
using Notes.DataModels.Models;
using Notes.ServiceModels.NotesModels;

namespace Notes.DependencyInjection
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection RegisterDataDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
            return services;
        }  
        
    }
}
