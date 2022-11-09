namespace PeezyMovies.Core.Models
{
    using System.ComponentModel.DataAnnotations;


    public class AddCinemaViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Logo { get; set; }
        [Required]
        [MaxLength(25)]
        [Display(Name = "Movie Title")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Max length - 100 chars.")]
        public string Description { get; set; }

    }
}
