namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;

    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;

        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        public IActionResult Index() => this.View();

        public IActionResult AjaxDemo() => this.View();
        
        public async Task<IActionResult> AjaxData()
        {
            var result = await this.aboutService.GetActorsInfo();
            return this.Json(result);
        }
    }
}
