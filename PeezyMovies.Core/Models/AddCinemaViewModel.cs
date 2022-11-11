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
        [StringLength(100, ErrorMessage = "Max length - 100 chars.", MinimumLength = 5)]
        public string Description { get; set; }

    }
}
