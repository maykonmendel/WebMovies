using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMovies.Entities;
using WebMovies.Models.Context;

namespace WebMovies.Models.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly WebMoviesContext _context;

        public MovieRepository(WebMoviesContext context)
        {
            _context = context;
        }
        
        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies?.FirstOrDefault(p => p.Id == id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }
    }
}