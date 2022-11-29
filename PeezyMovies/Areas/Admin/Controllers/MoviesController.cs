namespace PeezyMovies.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;

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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if ((await movieService.Exists(id) == false))
            {
                return this.NotFound();
            }

            var movie = await this.movieService.GetMovieByIdAsync(id);

            var movieDropDowns = await movieService.GetActorsDropDown();

            ViewBag.Actors = new SelectList(movieDropDowns.Actors, "Id", "FullName");

            var viewModel = new EditMovieViewModel()
            {
                Id = id,
                Description = movie.Description,
                Director = movie.Director,
                CinemaId = movie.CinemaId,
                GenreId = movie.GenreId,
                Price = movie.Price,
                ImageUrl = movie.ImageUrl,
                Rating = movie.Rating,
                Title = movie.Title,
                MovieTrailer = movie.Trailer,
                ProducerId = movie.ProducerId,
                Cinemas = await movieService.GetCinemasAsync(),
                Genres = await movieService.GetGenresAsync(),
                Producers = await movieService.GetProducersAsync(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            await movieService.EditMovie(id, model);

            return this.Redirect(nameof(All));
        }

        public async Task<IActionResult> Details(int id)
        {
            if ((await movieService.Exists(id)) == false)
            {
                return this.NotFound();
            }
            var viewModel = await movieService.GetMovieByIdAsync(id);
            return View(viewModel);

        }

    }
}
