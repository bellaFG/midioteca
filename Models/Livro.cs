using Midioteca.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Midioteca.Models
{
    public class Livro : Midia
    {
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int AnoPublicacao { get; set; }
        public int? Paginas { get; set; }

        public string? CapaPath { get; set; }

        [NotMapped]
        public IFormFile? CapaUrl { get; set; }
    }
}
