namespace TechChallenge4.Tests.Integration
{
    [Collection("GenreIntegration")]
    public class GenreControllerIntegrationTest : BaseIntegrationTest
    {
        private readonly DbContextOptions<ApplicationContext> _dbContextOptions;
        private readonly ApplicationContext _applicationContext;
        private readonly GenreRepository _genreRepository;
        private readonly GenreService _genreService;
        private readonly GenreController _genreController;
        private Genre _genre = new("Genre Controller Seed", "");


        public GenreControllerIntegrationTest() : base()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(ConnectionString).Options;
            _applicationContext = new ApplicationContext(_dbContextOptions);
            _genreRepository = new GenreRepository(_applicationContext);
            _genreService = new GenreService(_genreRepository);
            _genreController = new GenreController(_genreService);
        }

        private void SeedDatabase(ApplicationContext dbContext)
        {
            var existingGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Genre Controller Seed");

            if (existingGenre != null)
            {
                _genre = existingGenre;
            }
            else
            {
                dbContext.Genres.Add(_genre);
                dbContext.SaveChanges();
            }
        }

        private static void DeleteSeedData(ApplicationContext dbContext)
        {
            var existingGenre = dbContext.Genres.FirstOrDefault(g => g.Name == "Genre Controller Seed");

            if (existingGenre != null)
            {
                dbContext.Genres.Remove(existingGenre);
                dbContext.SaveChanges();
            }
        }

        [Fact]
        public async Task Add_Returns_CreatedResultWithNewGenre()
        {
            // Act
            var result = await _genreController.Add(new GenreRequestDto(_genre.Name, _genre.Description));

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            var genre = Assert.IsType<Genre>(createdResult.Value);
            Assert.Equal(_genre.Name, genre.Name);

            // Clean up
            DeleteSeedData(_applicationContext);
        }

        [Fact]
        public async Task GetAllGenres_Returns_AllGenres()
        {
            // Arrange
            SeedDatabase(_applicationContext);

            // Act
            var result = await _genreController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Genre>>(okResult.Value);

            // Clean up
            DeleteSeedData(_applicationContext);
        }

        [Fact]
        public async Task Update_Returns_OkResult()
        {
            // Arrange
            SeedDatabase(_applicationContext);

            // Act
            var result = await _genreController.Update(_genre);

            // Assert
            Assert.IsType<OkResult>(result);

            // Clean up
            DeleteSeedData(_applicationContext);
        }

        [Fact]
        public async Task Remove_Returns_OkResult()
        {
            // Arrange
            SeedDatabase(_applicationContext);

            // Act
            var result = await _genreController.Remove(_genre.Id);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
