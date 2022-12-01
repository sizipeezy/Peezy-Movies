namespace PeezyMovies.Infrastructure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Category.NameMaxLength)]
        public string Name { get; set; }

        public ICollection<MovieCategories> MovieCategories { get; set; } = new List<MovieCategories>();
    }
}
