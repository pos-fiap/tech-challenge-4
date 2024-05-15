using TechChallenge4.Application.DTOs;
using TechChallenge4.Application.Interfaces;
using TechChallenge4.Domain.Entities;
using TechChallenge4.Domain.Interfaces;

namespace TechChallenge4.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;

        public BookService(IBookRepository bookRepository, IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
        }

        public async Task<Book> Add(BookRequestDto book)
        {
            _ = _genreRepository.GetById(book.GenreId) ?? throw new Exception("Genre not found");

            Book bookEntity = new(book.Title, book.Author, book.GenreId);
            
            await _bookRepository.Add(bookEntity);
            
            return bookEntity;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            IEnumerable<Book> books = await _bookRepository.GetAll();
            return books.OrderBy(book => book.Title);
        }

        public async Task<IEnumerable<Book>> GetByGenre(int genreId)
        {
            IEnumerable<Book> books = await _bookRepository.GetAll(x => x.GenreId == genreId);
            if (!books.Any())
            {
                throw new Exception("There are no books in this genre.");
            }

            return books;
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
            _ = GetById(book.Id).Result;

            await _bookRepository.Update(book);
        }
    }
}
