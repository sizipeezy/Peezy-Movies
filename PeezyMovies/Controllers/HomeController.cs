namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Models;
    using System.Diagnostics;


    [Authorize(Roles = WebAppDataConstants.Admin)]
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        private readonly IMemoryCache cache;


        public HomeController(IHomeService homeService, IMemoryCache cache)
        {
            this.homeService = homeService;
            this.cache = cache;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(WebAppDataConstants.Admin))
            {
                return this.RedirectToAction("All", "Movies", new { area = "Admin" });
            }

            const string latestMoviesCache = "LatestMoviesCacheKey";

            var latest = this.cache.Get<IEnumerable<MovieViewModel>>(latestMoviesCache);

            if (latest == null)
            {
                latest = await this.homeService.GetLastThreeAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                this.cache.Set(latestMoviesCache, latest, cacheOptions);
            }

            return this.View(latest);

        }

        [AllowAnonymous]
        public IActionResult Chat() => this.View();

        [AllowAnonymous]
        public IActionResult NotFound(int statusCode)
        {
            var viewModel = new HttpErrorViewModel
            {
                StatusCode = statusCode,
            };

            if (statusCode == 404)
            {
                return this.View(viewModel);
            }

            return this.View(
                "Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}