using RateAndShare.Models;
using System.Data.Entity;

namespace RateAndShare.Controllers
{
    public class RateAndShareContext : DbContext
    {
        public RateAndShareContext() : base("name=RateAndShareContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .HasKey(song => song.SongId);

            modelBuilder.Entity<Rate>()
                .HasKey(rate => rate.ID);
        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
}