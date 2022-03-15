namespace CdOrganizer.Models
{
  public class GenreArtist
    {       
        public int GenreArtistId { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
    }
}