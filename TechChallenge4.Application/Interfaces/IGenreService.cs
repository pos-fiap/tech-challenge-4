using TechChallenge4.Domain.Entities;

namespace TechChallenge4.Application.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAll();

        Task<Genre> GetById(int id);

        Task Add(Genre genre);

        Task Update(Genre genre);

        Task Remove(int id);


    }
}
