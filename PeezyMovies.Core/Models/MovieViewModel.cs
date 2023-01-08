namespace PeezyMovies.Core.Models
{
    using PeezyMovies.Core.Models.ExtensionModel;


    public class MovieViewModel : IMovieModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public decimal Rating { get; set; }
        public string ImageUrl { get; set; }
        public string MovieTrailer { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Producer { get; set; }
        public string? Cinema { get; set; }
        public string? Genre { get; set; }

    }
}
