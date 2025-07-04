using System.ComponentModel.DataAnnotations;

namespace MidiotecaWeb.Dtos.Livro
{
    public class LivroUpdateDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Editora { get; set; }

        [Required]
        public int AnoPublicacao { get; set; }

        [Required]
        public Guid GeneroId { get; set; }
    }
}
