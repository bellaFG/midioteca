using System.ComponentModel.DataAnnotations;

namespace Midioteca.Dtos.Livro
{
    public class LivroCreateDto
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
