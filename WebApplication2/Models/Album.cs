using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }

        public string Titolo { get; set; }
        public string Genere { get; set; }
        public DateTime? AnnoDiPubblicazione { get; set; }
        public string Artist { get; set; }

        public virtual Artist ArtistNavigation { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
