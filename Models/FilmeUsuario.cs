using System.Data;

namespace Midioteca.Models
{
    public class FilmeUsuario : Entity
    {
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Guid FilmeId { get; set; }
        public Filme filme { get; set; }

        public StatusFilme Status { get; set; } = StatusFilme.Nenhum;

        public DateTime? DataFilme { get; set; }
        public int? Nota { get; set; }

    }
    public enum StatusFilme
    {
        Nenhum = 0,
        DesejoAssistir = 1,
        Assistido = 2
    }
}