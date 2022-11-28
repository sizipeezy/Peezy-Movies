namespace PeezyMovies.Core.Models
{
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class AddMovieViewModel
    {
        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 40 chars.")]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Director's name must be between 5 and 50 chars.")]
        public string Director { get; set; }

        [Required( ErrorMessage = "Enter price between 1$ and 500$")]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Display(Name = "Trailer's Url")]
        [Required]
        [Url]
        public string MovieTrailer { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        
        public decimal Rating { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Enter a description with maximum 200 chars")]
        public string Description { get; set; }

        public bool IsDeleted { get; set; } = false;

        [Display(Name = "Select actor(s)")]
        [Required]
        public List<int> ActorIds { get; set; }

        [Required]
        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();

        [Required]
        public int CinemaId { get; set; }

        public IEnumerable<Cinema> Cinemas { get; set; } = new List<Cinema>();

        [Required]
        public int ProducerId { get; set; }

        public IEnumerable<Producer> Producers { get; set; } = new List<Producer>();
    }
}
