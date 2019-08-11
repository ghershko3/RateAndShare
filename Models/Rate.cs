using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateAndShare.Models
{
    public class Rate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int SongId { get; set; }

        [Range(0,5)]
        [Required]
        public int NumOfStars { get; set; }
        
        public int UserId { get; set; }

        public Song Song { get; set; }

        public User User { get; set; }
    }
}