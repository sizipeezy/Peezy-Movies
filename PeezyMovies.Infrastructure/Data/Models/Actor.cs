
namespace PeezyMovies.Infrastructure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string? Bio { get; set; }

        public List<ActorMovie> Movies { get; set; } = new List<ActorMovie>();
    }
}
