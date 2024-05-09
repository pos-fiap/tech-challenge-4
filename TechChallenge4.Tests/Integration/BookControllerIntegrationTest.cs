using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Transactions;
using TechChallenge4.Api.Controllers;
using TechChallenge4.Domain.Entities;
using TechChallenge4.Infra.Data.Context;
using TechChallenge4.Infra.IoC;

namespace TechChallenge4.Tests.Integration
{
    [Collection("BookIntegration")]
    public class BookControllerIntegrationTest
    {
        private DbContextOptions<ApplicationContext> _dbContextOptions;
        private ApplicationContext _applicationContext;
        private BookRepository _bookRepository;
        private BookService _bookService;
        private BookController _bookController;
        private Book _book = new Book("Book Seed", "Author Seed", 1);
        private Genre _genre = new Genre("Genero Seed", "");

        public BookControllerIntegrationTest()
        {
            Configure();
        }

        private void Configure()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;;Initial Catalog=TechChallenge4;Integrated Security=True;Trusted_Connection=true; TrustServerCertificate=true").Options;
            _applicationContext = new ApplicationContext(_dbContextOptions);
            _bookRepository = new BookRepository(_applicationContext);
            _bookService = new BookService(_bookRepository);
            _bookController = new BookController(_bookService);
        }

        private void SeedDatabase(ApplicationContext dbContext)
        {
            var existingBook = dbContext.Books.FirstOrDefault(b => b.Title == "Book Seed");
            var existingGenre = dbContext.Genres.FirstOrDefault(g => g.Id == 1);

            if (existingBook is not null)
            {
                return;
            }

            if (existingGenre == null)
            {
                dbContext.Genres.Add(_genre);
                dbContext.SaveChanges();
            }

            dbContext.Books.Add(_book);
            dbContext.SaveChanges();
        }

        [Fact]
        public async Task Add_Returns_CreatedResultWithNewBook()
        {
            //Arrange
            var _bookRequestDto = new BookRequestDto(_book.Title, _book.Author, _book.GenreId);
            // Act
            var result = await _bookController.Add(_bookRequestDto);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            var book = Assert.IsType<Book>(createdResult.Value);
            Assert.Equal(_bookRequestDto.Title, book.Title);
        }

        [Fact]
        public async Task GetAllBooks_Returns_AllBooks()
        {
            SeedDatabase(_applicationContext);
            // Act
            var result = await _bookController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);
        }

        [Fact]
        public async Task GetByGenre_Returns_BooksOfGivenGenre()
        {
            // Act
            var result = await _bookController.GetByGenre(_book.GenreId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);
        }

        [Fact]
        public async Task Update_Returns_OkResult()
        {
            // Act
            var result = await _bookController.Update(_book);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Remove_Returns_OkResult()
        {
            // Act
            var result = await _bookController.Remove(_book.Id);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
