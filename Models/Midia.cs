using Midioteca.Models;
namespace Midioteca.Models
{
    public abstract class Midia : Entity
    {
        public string Titulo { get; set; } = null!;
        public Guid GeneroId { get; set; }
        public Genero Genero { get; set; } = null!;
    }
}
