namespace PeezyMovies.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;


    public class AddActorViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        [Url]
        public string ImageUrl { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string? Bio { get; set; }
    }
}
