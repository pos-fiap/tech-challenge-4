using TechChallenge4.Application.DTOs;
using TechChallenge4.Application.Interfaces;
using TechChallenge4.Domain.Entities;
using TechChallenge4.Domain.Interfaces;

namespace TechChallenge4.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Genre> Add(GenreRequestDto genre)
        {
            Genre genreEntity = new(genre.Name, genre.Description);
            await _genreRepository.Add(genreEntity);
            return genreEntity;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            IEnumerable<Genre> genres = await _genreRepository.GetAll();
            return genres.OrderBy(gen => gen.Name);
        }

        public async Task<Genre> GetById(int id)
        {
            Genre? genre = await _genreRepository.GetById(id);

            return genre ?? throw new Exception("Genre not found");
        }

        public async Task Remove(int id)
        {
            await _genreRepository.Delete(await GetById(id));
        }

        public async Task Update(Genre genre)
        {
            _ = await GetById(genre.Id);
            await _genreRepository.Update(genre);
        }
    }
}
