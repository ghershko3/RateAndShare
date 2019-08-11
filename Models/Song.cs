using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateAndShare.Models
{
    public class Song
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SongId { get; set; }

        [StringLength(50)]
        [Required]
        [DisplayName("Song Name")]
        public string SongName { get; set; }

        [StringLength(100)]
        [DisplayName("Artist Name")]
        public string ArtistName { get; set; }

        [StringLength(20)]
        public string Genre { get; set; }

        [DisplayName("Youtube Link")]
        public string YoutubeLink { get; set; }
    }
}