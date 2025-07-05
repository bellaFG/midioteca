using Microsoft.EntityFrameworkCore;
using Midioteca.Models;

namespace Midioteca.Data
{
    public class MidiotecaDbContext : DbContext
    {
        public MidiotecaDbContext(DbContextOptions<MidiotecaDbContext> options)
            : base(options)
        { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<LivroUsuario> LivroUsuario { get; set; }
        public DbSet<FilmeUsuario> FilmeUsuario { get; set; }
        public DbSet<Resenha> Resenhas { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}
