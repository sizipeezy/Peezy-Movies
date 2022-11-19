namespace PeezyMovies.Core.Models
{
    using Ganss.Xss;
    using System.ComponentModel.DataAnnotations;

    public class ContactFormViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Subject must be at least {2} and not more than {1} symbols.", MinimumLength = 5)]

        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter message.")]
        [StringLength(10000, ErrorMessage = "Message must be at least {2} symbols.", MinimumLength = 20)]
        [Display(Name = "Message description")]
        public string Content { get; set; }

        public string SanitezedContect => new HtmlSanitizer().Sanitize(Content);    
    }
}
