using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Song
    {
        public Song()
        {
            ListSongPlaylists = new HashSet<ListSongPlaylist>();
        }

        public string Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }

        public virtual Album AlbumNavigation { get; set; }
        public virtual Artist ArtistNavigation { get; set; }
        public virtual ICollection<ListSongPlaylist> ListSongPlaylists { get; set; }
    }
}
