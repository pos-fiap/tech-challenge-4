using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task Add(Genre genre)
        {
            await _genreRepository.Add(genre);
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
           return await _genreRepository.GetAll();
        }

        public async Task<Genre> GetById(int id)
        {
            var genre = await _genreRepository.GetById(id);

            return genre ?? throw new Exception("Genre not found");
        }

        public async Task Remove(int id)
        {
            await _genreRepository.Delete(await GetById(id));
        }

        public async Task Update(Genre genre)
        {
            await _genreRepository.Update(genre);
        }
    }
}
