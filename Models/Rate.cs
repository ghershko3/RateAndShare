using System.ComponentModel.DataAnnotations;

namespace RateAndShare.Models
{
    public class Rate
    {
        [Required]
        public int ID { get; set; }

        [Range(0,5)]
        [Required]
        public int NumOfStars { get; set; }

        [Required]
        public int SongId { get; set; }

        public Song Song { get; set; }
    }
}