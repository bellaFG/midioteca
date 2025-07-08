using Midioteca.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Midioteca.Models
{
    public class Filme : Midia
    {
        public string Diretor { get; set; }
        public int AnoLancamento { get; set; }
        public int? Duracao { get; set; }

        public string? CapaPath { get; set; }

        [NotMapped]
        public IFormFile? CapaUrl { get; set; }
    }
}