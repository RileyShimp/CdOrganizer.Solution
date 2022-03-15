using System.Collections.Generic;

namespace CdOrganizer.Models
{
    public class Genre
    {
        public Genre()
        {
            this.JoinEntities = new HashSet<GenreArtist>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GenreArtist> JoinEntities { get; set; }
    }
}