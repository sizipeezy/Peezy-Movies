namespace PeezyMovies.Infrastructure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Producer.ProducerMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
