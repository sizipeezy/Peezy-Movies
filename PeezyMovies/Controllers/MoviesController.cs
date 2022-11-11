namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
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
            var movieDropDowns = await movieService.GetActorsDropDown();

            ViewBag.Actors = new SelectList(movieDropDowns.Actors, "Id", "FullName");

            var viewModel = new AddMovieViewModel()
            {
              
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
                var movieDropDowns = await movieService.GetActorsDropDown();
                ViewBag.Actors = new SelectList(movieDropDowns.Actors, "Id", "FullName");
                return this.View(model);
            }

            await movieService.AddMovieAsync(model);

            return this.RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Details(int movieId)
        {
            var viewModel = await movieService.GetMovieByIdAsync(movieId);
            return View(viewModel);

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

        public async Task<IActionResult> Filter(string input)
        {
            var allMovies = await movieService.GetAllAsync();

            if(!string.IsNullOrEmpty(input) || !string.IsNullOrWhiteSpace(input))
            {
                var filteredResults = allMovies.Where(x => x.Title.Contains(input)).ToList();
                return this.View(nameof(All), filteredResults);
            }

            return this.View(nameof(All), allMovies);
        }
    }
}
