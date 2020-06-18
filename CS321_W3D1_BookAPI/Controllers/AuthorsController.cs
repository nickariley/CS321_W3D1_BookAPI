using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;
using CS321_W3D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService myAuthorService)
        {
            _authorService = myAuthorService;
        }
        // GET: api/<AuthorsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAll());
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _authorService.Get(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public IActionResult Post([FromBody] Author myNewAuthor)
        {
            var author = _authorService.Add(myNewAuthor);
            if (author == null) return BadRequest();
            return CreatedAtAction("Get", new { Id = myNewAuthor.Id }, myNewAuthor);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author myUpdatedAuthor)
        {
            var author = _authorService.Update(myUpdatedAuthor);
            if (author == null) return BadRequest();
            return Ok(author);
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _authorService.Get(id);
            _authorService.Delete(author);
            return NoContent();
        }
    }
}
