using System;
using System.Collections.Generic;
using Midioteca.Models;

namespace Midioteca.Models
{
    public class ConsumoMidia : Entity
    {
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public Guid MidiaId { get; set; }
        public Midia Midia { get; set; } = null!;

        public StatusMidia Status { get; set; } = StatusMidia.Nenhum;

        public DateTime? DataFinalizacao { get; set; }

        public int? Nota { get; set; }

        public virtual ICollection<Resenha> Resenhas { get; set; } = new List<Resenha>();

    }

    public enum StatusMidia
    {
        Nenhum = 0,
        DesejoConsumir = 1,
        Consumindo = 2,
        Consumido = 3,
        Abandonado = 4
    }
}
