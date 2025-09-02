using System.ComponentModel.DataAnnotations;

namespace MidiotecaApi.Models
{
    /// <summary>
    /// Application user.
    /// JWT will carry User.Id as claim.
    /// </summary>
    public class User : Entity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<MediaConsumption> MediaConsumptions { get; set; } = new List<MediaConsumption>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }

}
