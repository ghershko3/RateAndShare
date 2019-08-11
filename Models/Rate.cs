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
        
        [Required]
        public int UserId { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual Song Song { get; set; }

        public virtual User User { get; set; }
    }
}