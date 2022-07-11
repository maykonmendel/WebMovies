namespace WebMovies.Entities
{
    public class Director
    {
        public Director(string name)
        {
            Name = name;
            Movies = new List<Movie>();            
        }

        public int Id { get; private set; }
        public string? Name { get; private set; }
        public List<Movie>? Movies { get; set; }

        public void Update(string? name)
        {
            Name = name;
        }
    }
}