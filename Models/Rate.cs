using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateAndShare.Models
{
    public class Rate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [DisplayName("Song")]
        public int SongId { get; set; }

        [Range(0,5)]
        [Required]
        [DisplayName("Rate")]
        public int NumOfStars { get; set; }
        
        [Required]
        public int UserId { get; set; }

        public virtual Song Song { get; set; }

        public virtual User User { get; set; }
    }
}