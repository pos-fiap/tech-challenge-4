using TechChallenge4.Application.DTOs;
using TechChallenge4.Domain.Entities;

namespace TechChallenge4.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();

        Task<Book> GetById(int id);

        Task Add(BookRequestDto book);

        Task Update(Book book);

        Task Remove(int id);

        Task<IEnumerable<Book>> GetByGenre(int genreId);
    }
}
