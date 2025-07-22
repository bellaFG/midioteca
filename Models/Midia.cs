using Midioteca.Models;

namespace Midioteca.Models
{
    public enum TipoMidia
    {
        Livro,
        Filme
    }
    public abstract class Midia : Entity
    {
        public string Titulo { get; set; } = null!;
        public Guid GeneroId { get; set; }
        public Genero Genero { get; set; } = null!;

        public TipoMidia TipoMidia { get; set; }
    }
}
