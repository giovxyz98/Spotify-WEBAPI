using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Playlist
    {
        public int? CodiceIdentificativoPlaylist { get; set; }
        public string Nome { get; set; }
        public DateTime? DataDiCreazione { get; set; }
        public string DataUltimaModifica { get; set; }
        public int? Cod { get; set; }

        public virtual ListSongPlaylist CodNavigation { get; set; }
    }
}
