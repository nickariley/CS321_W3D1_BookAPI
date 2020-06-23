﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.ApiModels;
using CS321_W3D1_BookAPI.Models;
using CS321_W3D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService myBookService)
        {
            _bookService = myBookService;
        }

        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            var bookModels = _bookService
                 .GetAll()
                 .ToApiModels();
            return Ok(bookModels);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookService.Get(id).ToApiModel();
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] BookModel myNewBook)
        {
            var book = _bookService.Add(myNewBook.ToDomainModel());
            if (book == null) return BadRequest();
            return CreatedAtAction("Get", new { Id = myNewBook.Id }, myNewBook);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookModel myUpdatedBook)
        {
            var book = _bookService.Update(myUpdatedBook.ToDomainModel());
            if (book == null) return BadRequest();
            return Ok(book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.Get(id);
            _bookService.Delete(book);
            return NoContent();
        }

        // GET api/author/{authorId}/books
        // NOTE that the route specified in HttpGet begins with a forward slash.
        // This overrides the Route("/api/[controller]") specified on the BooksController
        // class.
        [HttpGet("/api/authors/{authorId}/books")]
        public IActionResult GetBooksForAuthor(int authorId)
        {
            var bookModels = _bookService
                .GetBooksForAuthor(authorId)
                .ToApiModels();

            return Ok(bookModels);
        }

        [HttpGet("/api/publishers/{publisherId}/books")]
        public IActionResult GetBooksForPublisher(int publisherId)
        {
            var bookModels = _bookService
                .GetBooksForPublisher(publisherId)
                .ToApiModels();

            return Ok(bookModels);
        }
    }
}
