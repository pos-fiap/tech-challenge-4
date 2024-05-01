using Microsoft.EntityFrameworkCore;
using TechChallenge4.Domain.Entities;

namespace TechChallenge4.Infra.Data.Context
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
