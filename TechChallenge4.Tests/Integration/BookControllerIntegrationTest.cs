namespace TechChallenge4.Tests.Integration
{
    [Collection("BookIntegration")]
    public class BookControllerIntegrationTest : BaseIntegrationTest
    {
        private DbContextOptions<ApplicationContext> _dbContextOptions;
        private ApplicationContext _applicationContext;
        private BookRepository _bookRepository;
        private BookService _bookService;
        private BookController _bookController;
        private Book _book;
        private Genre _genre = new("Genre Seed", "");

        public BookControllerIntegrationTest() : base()
        {
            Configure();
        }

        private void Configure()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(ConnectionString).Options;
            _applicationContext = new ApplicationContext(_dbContextOptions);
            _bookRepository = new BookRepository(_applicationContext);
            _bookService = new BookService(_bookRepository);
            _bookController = new BookController(_bookService);
        }

        private void SeedDatabase(ApplicationContext dbContext)
        {
            CreateBookObjectWithGenreId(dbContext);

            dbContext.Books.Add(_book);
            dbContext.SaveChanges();
        }

        private void CreateBookObjectWithGenreId(ApplicationContext dbContext)
        {
            var existingBook = dbContext.Books.FirstOrDefault(b => b.Title == "Book Seed");
            var existingGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Genre Seed");

            if (existingBook is not null)
            {
                _book = existingBook;
                return;
            }

            if (existingGenre != null)
            {
                _genre = existingGenre;
            }
            else
            {
                dbContext.Genres.Add(_genre);
                dbContext.SaveChanges();
            }

            _book = new Book("Book Seed", "Author Seed", _genre.Id);
        }

        private void DeleteSeedData(ApplicationContext dbContext)
        {
            var existingBook = dbContext.Books.FirstOrDefault(b => b.Title == "Book Seed");
            var existingGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Genre Seed");

            if (existingBook != null)
            {
                dbContext.Books.Remove(existingBook);
                dbContext.SaveChanges();
            }

            if (existingGenre != null)
            {
                dbContext.Genres.Remove(existingGenre);
                dbContext.SaveChanges();
            }
        }

        [Fact]
        public async Task Add_Returns_CreatedResultWithNewBook()
        {
            //Arrange
            CreateBookObjectWithGenreId(_applicationContext);

            var _bookRequestDto = new BookRequestDto(_book.Title, _book.Author, _book.GenreId);
            // Act
            var result = await _bookController.Add(_bookRequestDto);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            var book = Assert.IsType<Book>(createdResult.Value);
            Assert.Equal(_bookRequestDto.Title, book.Title);

            DeleteSeedData(_applicationContext);
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

            DeleteSeedData(_applicationContext);
        }

        [Fact]
        public async Task GetByGenre_Returns_BooksOfGivenGenre()
        {
            // Arrange
            SeedDatabase(_applicationContext);

            // Act
            var result = await _bookController.GetByGenre(_book.GenreId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);

            DeleteSeedData(_applicationContext);
        }

        [Fact]
        public async Task Update_Returns_OkResult()
        {
            // Arrange
            SeedDatabase(_applicationContext);

            // Act
            var result = await _bookController.Update(_book);

            // Assert
            Assert.IsType<OkResult>(result);

            DeleteSeedData(_applicationContext);
        }

        [Fact]
        public async Task Remove_Returns_OkResult()
        {
            // Arrange
            SeedDatabase(_applicationContext);

            // Act
            var result = await _bookController.Remove(_book.Id);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
