namespace PeezyMovies.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string UserId { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
