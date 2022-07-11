using Microsoft.AspNetCore.Mvc;
using WebMovies.Entities;
using WebMovies.Models;
using WebMovies.Models.Repositories;

namespace WebMovies.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _repository;

        public MoviesController(IMovieRepository repository)
        {
            _repository = repository;
        }

        // GET: api/movies
        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _repository.GetAll();

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        //GET: api/movies/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _repository.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        //POST: api/movies
        [HttpPost]
        public IActionResult Post(int directorId, MovieModel model)
        {
            var movie = new Movie(model.Title, directorId, model.ReleaseDate);

            if (model.Title == null)
            {
                return BadRequest("Title is not null.");
            }
            
            _repository.Add(movie);

            return CreatedAtAction(nameof(GetById), new { id = movie.Id, directorId = directorId }, movie);
        }

        //PUT: api/movies/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, MovieModel model)
        {
            var movie = _repository.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            movie.Update(model.Title, model.DirectorId, model.ReleaseDate);
            _repository.Update(movie);

            return NoContent();
        }

        //DELETE: api/movies/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _repository.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            _repository.Delete(movie.Id);

            return NoContent();
        }

    }
}