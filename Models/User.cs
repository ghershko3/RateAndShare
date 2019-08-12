using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required, DataType(DataType.Password), MinLength(3), MaxLength(10)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string Email { get; set; }

        public bool IsAdmin { get; private set; }

        [DisplayName("Country")]
        public int CountryId { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }

        public virtual Country Country { get; set; }
    }
}