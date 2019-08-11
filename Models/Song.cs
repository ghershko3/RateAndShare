using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RateAndShare.Models
{
    public class Song
    {
        public int ID { get; set; }

        [DisplayName("Song Name")]
        public string SongName { get; set; }

        [DisplayName("Artist Name")]
        public string ArtistName { get; set; }

        [DisplayName("Genre")]
        public string Genre { get; set; }

        [DisplayName("Youtube Link")]
        public string YoutubeLink { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }
    }
}