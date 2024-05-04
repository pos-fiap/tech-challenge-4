using Microsoft.AspNetCore.Mvc;
using TechChallenge4.Application.DTOs;
using TechChallenge4.Application.Interfaces;
using TechChallenge4.Domain.Entities;

namespace TechChallenge4.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _genreService.GetAll();
            return Ok(genres);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var genre = await _genreService.GetById(id);
            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GenreRequestDto genre)
        {
            await _genreService.Add(genre);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Genre genre)
        {
            await _genreService.Update(genre);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _genreService.Remove(id);
            return Ok();
        }
    }
}
