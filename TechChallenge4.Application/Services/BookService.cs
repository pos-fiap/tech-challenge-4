using TechChallenge4.Application.DTOs;
using TechChallenge4.Application.Interfaces;
using TechChallenge4.Domain.Entities;
using TechChallenge4.Domain.Interfaces;

namespace TechChallenge4.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Add(BookRequestDto book)
        {
            Book bookEntity = new(book.Title, book.Author, book.GenreId);
            await _bookRepository.Add(bookEntity);
            return bookEntity;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<IEnumerable<Book>> GetByGenre(int genreId)
        {
            return await _bookRepository.GetAll(x => x.GenreId == genreId);
        }

        public async Task<Book> GetById(int id)
        {
            var book = await _bookRepository.GetById(id);
            return book ?? throw new Exception("Book not found");
        }

        public async Task Remove(int id)
        {
            await _bookRepository.Delete(await GetById(id));
        }

        public async Task Update(Book book)
        {
            await _bookRepository.Update(book);
        }
    }
}
