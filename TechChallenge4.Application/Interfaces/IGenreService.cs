using TechChallenge4.Application.DTOs;
using TechChallenge4.Domain.Entities;

namespace TechChallenge4.Application.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAll();

        Task<Genre> GetById(int id);

        Task<Genre> Add(GenreRequestDto genre);

        Task Update(Genre genre);

        Task Remove(int id);


    }
}
