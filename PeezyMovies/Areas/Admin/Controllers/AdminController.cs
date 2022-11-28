namespace PeezyMovies.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Area(WebAppDataConstants.Admin)]
    [Route("Admin/[controller]/[Action]/{id?}")]
    public abstract class AdminController : Controller
    {
    
    }
}
