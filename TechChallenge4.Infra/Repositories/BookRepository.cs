using TechChallenge4.Domain.Entities;
using TechChallenge4.Domain.Interfaces;
using TechChallenge4.Infra.Data.Context;
using TechChallenge4.Infra.Data.Repositories;

namespace TechChallenge4.Infra.IoC
{
    public class BookRepository(ApplicationContext context) : BaseRepository<Book>(context), IBookRepository
    {
    }
}