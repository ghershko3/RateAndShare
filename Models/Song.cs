using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateAndShare.Models
{
    public class Song
    { 
        public Song()
        {
            this.Rates = new HashSet<Rate>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public virtual ICollection<Rate> Rates { get; set; }
    }
}