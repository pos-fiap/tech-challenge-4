using TechChallenge4.Domain.Entities;
using TechChallenge4.Domain.Interfaces;
using TechChallenge4.Infra.Data.Context;

namespace TechChallenge4.Infra.Data.Repositories
{
    public class GenreRepository(ApplicationContext context) : BaseRepository<Genre>(context), IGenreRepository
    {
    }
}
