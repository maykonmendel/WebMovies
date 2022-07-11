using Microsoft.EntityFrameworkCore;
using WebMovies.Entities;

namespace WebMovies.Models.Context
{
    public class WebMoviesContext : DbContext
    {
        public WebMoviesContext(DbContextOptions<WebMoviesContext> options) : base(options)
        {

        }

        public DbSet<Director>? Directors { get; set; }
        public DbSet<Movie>? Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Director>(e =>
            {
                e.HasMany(d => d.Movies)
                    .WithOne()
                    .HasForeignKey(m => m.DirectorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}