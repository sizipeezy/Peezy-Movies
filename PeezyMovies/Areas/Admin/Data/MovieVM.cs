namespace PeezyMovies.Areas.Admin.Data
{
    using PeezyMovies.Core.Models;
    using PeezyMovies.Infrastructure.Data.Models;


    public class MovieVM
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Director { get; set; }

        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public string MovieTrailer { get; set; }

        public decimal Rating { get; set; }
        public string Description { get; set; }

        public List<ActorsViewModel> Actors { get; set; }

        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();

        public int CinemaId { get; set; }

        public IEnumerable<Cinema> Cinemas { get; set; } = new List<Cinema>();

        public int ProducerId { get; set; }

        public IEnumerable<Producer> Producers { get; set; } = new List<Producer>();
    }
}
