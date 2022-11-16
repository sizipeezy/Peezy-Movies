namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using PeezyMovies.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IRepository repo;

        public HomeController(IRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult AjaxDemo()
        {
            return this.View();
        }

        public IActionResult AjaxData()
        {
            var result = this.repo.All<Actor>().ToList();
            return this.Json(result);
        }
        public IActionResult Index()
        {
            if (User?.Identity.IsAuthenticated ?? false)
            {
                return this.RedirectToAction("Index", "Movies");
            }
            return View();
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