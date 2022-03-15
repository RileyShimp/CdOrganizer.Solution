using Microsoft.EntityFrameworkCore;

namespace CdOrganizer.Models
{
  public class CdOrganizerContext : DbContext
  {
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<GenreArtist> GenreArtist { get; set; }

    public CdOrganizerContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}