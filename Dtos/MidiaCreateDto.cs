using Midioteca.Models;

namespace Midioteca.Dtos
{
    public class MidiaCreateDto
    {
        public string Titulo { get; set; } = null!;
        public Guid GeneroId { get; set; }
        public TipoMidia Tipo { get; set; }

        public string? Autor { get; set; }
        public string? Editora { get; set; }
        public int? AnoPublicacao { get; set; }
        public int? Paginas { get; set; }

        public string? Diretor { get; set; }
        public int? AnoLancamento { get; set; }
        public int? Duracao { get; set; }
    }
}
