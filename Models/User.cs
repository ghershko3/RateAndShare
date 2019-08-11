using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RateAndShare.Models
{
    public class User
    {
        public User()
        {
            this.Rates = new HashSet<Rate>();
            this.IsAdmin = false;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [StringLength(50)]
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password), MinLength(3), MaxLength(10)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public bool IsAdmin { get; private set; }

        public virtual ICollection<Rate> Rates { get; set; }
    }
}