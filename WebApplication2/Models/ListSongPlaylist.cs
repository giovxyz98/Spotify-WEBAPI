using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class ListSongPlaylist
    {
        public int CodiceIdentificativoPlaylist { get; set; }
        public string Title { get; set; }

        public virtual Song TitleNavigation { get; set; }
    }
}
