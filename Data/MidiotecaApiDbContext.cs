using Microsoft.EntityFrameworkCore;
using MidiotecaApi.Models;

namespace MidiotecaApi.Data
{
    public class MidiotecaApiDbContext : DbContext
    {
        public MidiotecaApiDbContext(DbContextOptions<MidiotecaApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MediaConsumption> MediaConsumptions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<MediaItemGenre> MediaItemGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MediaItemGenre>()
                .HasKey(mg => new { mg.MediaItemId, mg.GenreId });

            modelBuilder.Entity<MediaItemGenre>()
                .HasOne(mg => mg.MediaItem)
                .WithMany(m => m.MediaItemGenres)
                .HasForeignKey(mg => mg.MediaItemId);

            modelBuilder.Entity<MediaItemGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MediaItemGenres)
                .HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<MediaConsumption>()
                .Property(m => m.PricePaid)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
