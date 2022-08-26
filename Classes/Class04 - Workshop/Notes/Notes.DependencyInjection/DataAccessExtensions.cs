using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notes.DataAccess;
using Notes.DataAccess.Data;
using Notes.DataAccess.Repositories;
using Notes.DataModels.Models;
using Notes.ServiceModels.NotesModels;

namespace Notes.DependencyInjection
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection RegisterDataDependencies(this IServiceCollection services)
        {


            //services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<IRepository<Note>, NoteEFRepository>();
            //services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<User>, UserEFRepository>();
            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NotesDbContext>(opt => opt.UseSqlServer(connectionString));
            return services;
        }

    }
}
