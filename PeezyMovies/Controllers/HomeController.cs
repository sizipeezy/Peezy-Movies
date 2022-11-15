namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using PeezyMovies.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IActorService actorService;
        private readonly IRepository repo;

        public HomeController(IActorService actorService, IRepository repo)
        {
            this.actorService = actorService;
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
        
    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}