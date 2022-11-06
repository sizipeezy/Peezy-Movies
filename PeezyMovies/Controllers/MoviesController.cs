using Microsoft.AspNetCore.Mvc;

namespace PeezyMovies.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
