namespace PeezyMovies.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(GlobalConstants.Conntact.NameMaxLength, MinimumLength = GlobalConstants.Conntact.NameMinLength)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Conntact.SubjectMaxLength)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Conntact.MessageMaxLength)]
        public string Message { get; set; }
    }
}
