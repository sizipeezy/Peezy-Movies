namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;


    public class CinemaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
