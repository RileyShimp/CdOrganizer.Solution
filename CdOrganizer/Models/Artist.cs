using System.Collections.Generic;

namespace CdOrganizer.Models
{
  public class Artist
  {
    public Artist()
    {
      this.JoinEntities = new HashSet<GenreArtist>();
    }

    public int ArtistId { get; set; }
    public string Description { get; set; }

    public virtual ICollection<GenreArtist> JoinEntities { get;}
  }
}
