using Microsoft.Extensions.DependencyInjection;
using TechChallenge4.Application.Interfaces;
using TechChallenge4.Application.Services;
using TechChallenge4.Domain.Interfaces;
using TechChallenge4.Infra.Data.Repositories;


namespace TechChallenge4.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IGenreService, GenreService>();
        }
    }
}
