using WebMovies.Entities;

namespace WebMovies.Models.Repositories
{
    public interface IDirectorRepository
    {
        List<Director> GetAll();
        Director GetById(int id);
        void Add(Director director);
        void Update(Director director);
        void Delete(int id);
    }
}