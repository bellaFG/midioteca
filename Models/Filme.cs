using System.ComponentModel.DataAnnotations.Schema;

namespace MidiotecaWeb.Models
{
    public class Filme : Entity
    {
        public string TituloFilme { get; set; }
        public string Diretor { get; set; }
        public int AnoLancamento { get; set; }

        public string? CapaPath { get; set; }

        [NotMapped]
        public IFormFile? CapaUrl { get; set; }

        public Guid GeneroId { get; set; }
        public Genero Genero { get; set; }

        public virtual ICollection<FilmeUsuario> UsuariosRelacionados { get; set; } = new List<FilmeUsuario>();
        public virtual ICollection<Resenha> Resenhas { get; set; } = new List<Resenha>();
    }
}