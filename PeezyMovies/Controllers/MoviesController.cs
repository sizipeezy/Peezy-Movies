namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using System.Security.Claims;

    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }
        public async Task<IActionResult> All()
        {
            var viewModel = await movieService.GetAllAsync();
            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var viewModel = new AddMovieViewModel()
            {
                Actors = await movieService.GetActors(),
                Cinemas = await movieService.GetCinemasAsync(),
                Genres = await movieService.GetGenresAsync(),
                Producers = await movieService.GetProducersAsync(),
            };

            return this.View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await movieService.AddMovieAsync(model);

            return this.RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Details()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Details(int movieId)
        {
            var movie = movieService.GetById(movieId);

            if(movie == null)
            {
                return this.View("NotFound");
            }

            return this.View(new EditMovieViewModel
            {
                Director = movie.Director,
                ImageUrl = movie.ImageUrl,
                Rating = movie.Rating,
                Title = movie.Title,
                Cinemas = await movieService.GetCinemasAsync(),
                Producers = await movieService.GetProducersAsync(),
                Genres = await movieService.GetGenresAsync(),
            });
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = await movieService.GetLastThreeAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var viewModel = await movieService.GetWatchedAsync(userId);
            return View(viewModel);
        }

        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            await movieService.AddMovieToCollectionAsync(userId, movieId);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            await movieService.RemoveFromCollectionAsync(userId, movieId);
            return RedirectToAction(nameof(Mine));
        }
    }
}
