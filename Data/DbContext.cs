using Microsoft.EntityFrameworkCore;
using Midioteca.Models;

namespace Midioteca.Data
{
    public class MidiotecaDbContext : DbContext
    {
        public MidiotecaDbContext(DbContextOptions<MidiotecaDbContext> options)
            : base(options)
        { }

        public DbSet<Midia> Midias { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ConsumoMidia> ConsumosMidia { get; set; }
        public DbSet<Resenha> Resenhas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Midia>().ToTable("Midias");
            modelBuilder.Entity<ConsumoMidia>().ToTable("ConsumoMidia");

            modelBuilder.Entity<ConsumoMidia>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.ConsumosMidia)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Resenha>()
                .HasOne(r => r.ConsumoMidia)
                .WithMany(c => c.Resenhas)
                .HasForeignKey(r => r.ConsumoMidiaId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}
