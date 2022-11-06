using Microsoft.AspNetCore.Mvc;

namespace PeezyMovies.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
