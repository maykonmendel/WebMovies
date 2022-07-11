namespace WebMovies.Entities
{
    public class Movie
    {
        public Movie(string? title, int directorId, DateTime releaseDate)
        {
            Title = title;
            DirectorId = directorId;
            ReleaseDate = releaseDate;
        }

        public int Id { get; private set; }
        public string? Title { get; private set; }        
        public int DirectorId { get; private set; }
        public DateTime ReleaseDate { get; private set; }

        public void Update(string? title, int directorId, DateTime releaseDate)
        {
            Title = title;
            DirectorId = directorId;
            ReleaseDate = releaseDate;
        }
    }
}