using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.ApiModels;
using CS321_W3D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService myPublisherService)
        {
            _publisherService = myPublisherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var publisherModels = _publisherService
                .GetAll()
                .ToApiModels();
            return Ok(publisherModels);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _publisherService
                .Get(id)
                .ToApiModel();
            if (author == null) return NotFound();
            return Ok(author);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public IActionResult Post([FromBody] PublisherModel myNewPublisher)
        {
            //var author = _authorService.Add(myNewAuthor);
            //if (author == null) return BadRequest();
            //return CreatedAtAction("Get", new { Id = myNewAuthor.Id }, myNewAuthor);

            try
            {
                // TODO: convert the newAuthor to a domain model
                // add the new author
                _publisherService.Add(myNewPublisher.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddPublisher", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            // return a 201 Created status. This will also add a "location" header
            // with the URI of the new author. E.g., /api/authors/99, if the new is 99
            return CreatedAtAction("Get", new { Id = myNewPublisher.Id }, myNewPublisher);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PublisherModel myUpdatedPublisher)
        {
            var publisher = _publisherService.Update(myUpdatedPublisher.ToDomainModel());
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _publisherService.Get(id);
            _publisherService.Delete(publisher);
            return NoContent();
        }
    }
}
