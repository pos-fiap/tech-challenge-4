namespace TechChallenge4.Tests.Services
{
    public class GenreServiceTest
    {
        private readonly Mock<IGenreRepository> _genreRepository;
        public GenreServiceTest() 
        { 
            _genreRepository = new Mock<IGenreRepository>(); 
        }

        [Fact]
        public async Task Add_WhenCalled_ReturnsGenre()
        {
            // Arrange
            var genreService = new GenreService(_genreRepository.Object);
            var genreRequestDto = new GenreRequestDto("Genre one", "Random description");
            
            // Act
            var result = await genreService.Add(genreRequestDto);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(genreRequestDto.Name, result.Name);
        }

        [Fact]
        public async Task GetAll_WhenCalled_ReturnsGenres()
        {
            // Arrange
            var genreService = new GenreService(_genreRepository.Object);
            var genres = new List<Genre>
            {
                new("Genre one", "Random description"),
                new("Genre two", "Random description")
            };
            _genreRepository.Setup(x => x.GetAll()).ReturnsAsync(genres);
            
            // Act
            var result = await genreService.GetAll();
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(genres.Count, result.Count());
        }


        [Fact]
        public async Task GetById_WhenCalled_ReturnsGenre()
        {
            // Arrange
            var genreService = new GenreService(_genreRepository.Object);
            var genre = new Genre("Genre one", "Random description");
            _genreRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(genre);
            
            // Act
            var result = await genreService.GetById(1);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(genre.Name, result.Name);
        }

        [Fact]
        public async Task Remove_WhenCalled_ReturnsVoid()
        {
            // Arrange
            var genreService = new GenreService(_genreRepository.Object);
            var genre = new Genre("Genre one", "Random description");
            _genreRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(genre);
            
            // Act
            await genreService.Remove(1);
            
            // Assert
            _genreRepository.Verify(x => x.Delete(It.IsAny<Genre>()), Times.Once);
        }

        [Fact]
        public async Task Update_WhenCalled_ReturnsVoid()
        {
            // Arrange
            var genreService = new GenreService(_genreRepository.Object);
            var genre = new Genre("Genre one", "Random description");
            _genreRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(genre);
            
            // Act
            await genreService.Update(genre);
            
            // Assert
            _genreRepository.Verify(x => x.Update(It.IsAny<Genre>()), Times.Once);
        }

    }
}
