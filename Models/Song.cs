using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateAndShare.Models
{
    public class Song
    {
        [Required]
        public int SongId { get; set; }

        [StringLength(50)]
        [Required]
        public string SongName { get; set; }

        [StringLength(100)]
        public string ArtistName { get; set; }

        [StringLength(20)]
        public string Genre { get; set; }

        [StringLength(30)]
        public string YoutubeLink { get; set; }
    }
}