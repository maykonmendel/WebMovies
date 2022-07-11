using Microsoft.EntityFrameworkCore;
using WebMovies.Entities;
using WebMovies.Models.Context;

namespace WebMovies.Models.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly WebMoviesContext _context;

        public DirectorRepository(WebMoviesContext context)
        {
            _context = context;
        }

        public void Add(Director director)
        {
            _context.Directors.Add(director);
            _context.SaveChanges();           
        }

        public void Delete(int id)
        {
            var director = _context.Directors?.FirstOrDefault(p => p.Id == id);
            
            if(director != null) 
            {
                _context.Directors.Remove(director);
                _context.SaveChanges();
            }
        }
        
        public List<Director> GetAll()
        {
            return _context.Directors.Include(p => p.Movies).ToList();
        }

        public Director GetById(int id)
        {
            return _context.Directors.Include(p => p.Movies).FirstOrDefault(p => p.Id == id);
        }

        public void Update(Director director)
        {
            _context.Directors.Update(director);
            _context.SaveChanges();
        }       
    }
}