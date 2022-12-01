namespace PeezyMovies.Infrastructure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Genre.GenreMaxLength)]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
