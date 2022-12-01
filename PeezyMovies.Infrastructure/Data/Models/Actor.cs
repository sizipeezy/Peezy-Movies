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
        [MaxLength(GlobalConstants.Actor.FullNameMaxLength)]
        public string FullName { get; set; }

        [MaxLength(GlobalConstants.Actor.BioMaxLength)]
        public string Bio { get; set; }

        public List<ActorMovie> Movies { get; set; } = new List<ActorMovie>();
    }
}
