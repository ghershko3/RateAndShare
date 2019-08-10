using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateAndShare.Models
{
    public class Song
    {
        public int ID { get; set; }
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string Genre { get; set; }
        public string YoutubeLink { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }
    }
}