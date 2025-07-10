using Midioteca.Models;

namespace Midioteca.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ConsumoMidia> ConsumosMidia { get; set; } = new List<ConsumoMidia>();

    }
}