namespace PeezyMovies.Core.Models
{
    using System.ComponentModel.DataAnnotations;


    public class AddProducerViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

    }
}
