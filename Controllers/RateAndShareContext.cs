using RateAndShare.Models;
using System.Data.Entity;

namespace RateAndShare.Controllers
{
    public class RateAndShareContext : DbContext
    {
        public RateAndShareContext()
        {

        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
}