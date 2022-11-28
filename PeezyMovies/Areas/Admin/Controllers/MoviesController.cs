namespace PeezyMovies.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;

    public class MoviesController : AdminController
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public async Task<IActionResult> All()
        {
            var movies = await this.movieService.GetAllAsync();

            return this.View(movies);
        }

    }
}
