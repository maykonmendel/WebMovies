using Microsoft.AspNetCore.Mvc;
using WebMovies.Entities;
using WebMovies.Models;
using WebMovies.Models.Repositories;

namespace WebMovies.Controllers
{
    [ApiController]
    [Route("api/directors")]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorRepository _repository;

        public DirectorsController(IDirectorRepository repository)
        {
            _repository = repository;
        }

        // GET: api/directors
        [HttpGet]
        public IActionResult GetAll()
        {
            var directors = _repository.GetAll();

            if (directors == null)
            {
                return NotFound();
            }

            return Ok(directors);
        }

        //GET: api/directors/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var director = _repository.GetById(id);

            if (director == null)
            {
                return NotFound();
            }

            return Ok(director);
        }

        //POST: api/directors
        [HttpPost]
        public IActionResult Post(DirectorModel model)
        {
            if(model.Name == null) 
            {
                return BadRequest("Name is not null.");
            }

            var director = new Director(model.Name);
            _repository.Add(director);

            return CreatedAtAction(nameof(GetAll), new { id = director.Id }, director);
        }

        //PUT: api/directors/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, DirectorModel model)
        {
            var director = _repository.GetById(id);

            if(director == null)
            {
                return NotFound();
            }

            director.Update(model.Name);
            _repository.Update(director);

            return NoContent();
        }

        //DELETE: api/Directors/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var director = _repository.GetById(id);

            if(director == null)
            {
                return NotFound();
            }

            _repository.Delete(director.Id);
            
            return NoContent();
        }
    }
}