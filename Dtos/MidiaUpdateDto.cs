

namespace Midioteca.Dtos
{
    public class MidiaUpdateDto
    {
        public Guid Id { get; set; }

        public string? Titulo { get; set; }
        public Guid? GeneroId { get; set; }
        public string? CapaPath { get; set; }

        public string? Autor { get; set; }
        public string? Editora { get; set; }
        public int? AnoPublicacao { get; set; }
        public int? Paginas { get; set; }

        public string? Diretor { get; set; }
        public int? AnoLancamento { get; set; }
        public int? Duracao { get; set; }
    }
}
