namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;

    [Authorize(Roles = WebAppDataConstants.Admin)]
    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;

        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        [AllowAnonymous]
        public IActionResult Index() => this.View();

        [AllowAnonymous]
        public async Task<IActionResult> AjaxData()
        {
            var result = await this.aboutService.GetActorsInfo();
            return this.Json(result);
        }
    }
}
