namespace PeezyMovies.Core.Models
{
    using System.Collections.Generic;

    public class AllMoviesViewModel
    {
        public const int moviesPerPage = 4;
        public string  Genre { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public MovieSorting Sorting { get; init; }
        public IEnumerable<MovieViewModel> Movies { get; set; }  = new List<MovieViewModel>();

        public int TotalCount { get; set; }
        public int CurrentPage { get; set; } = 1;

        public int MoviesPerPage { get; set; } = moviesPerPage;
    }
}
