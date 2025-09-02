using MidiotecaApi.Models;

using System.ComponentModel.DataAnnotations;

namespace MidiotecaApi.Models
{
    /// <summary>
    /// Genre entity — usada para filtros e pesquisas.
    /// </summary>
    public class Genre : Entity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual ICollection<MediaItemGenre> MediaItemGenres { get; set; } = new List<MediaItemGenre>();
    }
}