namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using PeezyMovies.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IRepository repo;
        private readonly IHomeService homeService;

        public HomeController(IRepository repo, IHomeService homeService)
        {
            this.repo = repo;
            this.homeService = homeService;
        }

        [Authorize(Roles = WebAppDataConstants.Admin)]
        public IActionResult AjaxDemo()
        {
            return this.View();
        }

        [Authorize(Roles = WebAppDataConstants.Admin)]
        public IActionResult AjaxData()
        {
            var result = this.repo.All<Actor>().ToList();
            return this.Json(result);
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = await homeService.GetLastThreeAsync();

            return View(viewModel);
        }

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