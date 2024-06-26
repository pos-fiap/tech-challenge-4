﻿using Microsoft.AspNetCore.Mvc;
using TechChallenge4.Application.DTOs;
using TechChallenge4.Application.Interfaces;
using TechChallenge4.Domain.Entities;

namespace TechChallenge4.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAll();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetById(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookRequestDto book)
        {
            var result = await _bookService.Add(book);
            return Created(string.Empty, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Book book)
        {
            await _bookService.Update(book);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _bookService.Remove(id);
            return Ok();
        }

        [HttpGet("genre/{genreId:int}")]
        public async Task<IActionResult> GetByGenre(int genreId)
        {
            var books = await _bookService.GetByGenre(genreId);
            return Ok(books);
        }
    }
}
