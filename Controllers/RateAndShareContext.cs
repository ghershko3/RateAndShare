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
            // Primary key definition
            modelBuilder.Entity<Song>()
                .HasKey(song => song.SongId);

            modelBuilder.Entity<Rate>()
                .HasKey(rate => rate.ID);

            modelBuilder.Entity<User>()
                .HasKey(user => user.UserId);

            modelBuilder.Entity<Country>()
                .HasKey(country => country.Id);

            // Foreign key definition
            modelBuilder.Entity<Rate>()
                .HasRequired(rate => rate.Song).WithMany(song => song.Rates).HasForeignKey(rate => rate.SongId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Rate>()
                .HasRequired(rate => rate.User).WithMany(user => user.Rates).HasForeignKey(rate => rate.UserId).WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
                .HasRequired(user => user.Country).WithMany(country => country.Users).HasForeignKey(user => user.CountryId).WillCascadeOnDelete(true);
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<RateAndShare.Models.Country> Countries { get; set; }
    }
}