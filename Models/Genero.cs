using Midioteca.Models;

namespace Midioteca.Models
{
    public class Genero : Entity
    {
        public string Nome { get; set; }
        public virtual ICollection<Midia> Midias { get; set; } = new List<Midia>();
    }
}