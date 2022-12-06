namespace PeezyMovies.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Message
    {
        [Required]
        public string User { get; set; }

        [Required]

        public string Text { get; set; }
    }
}
