namespace PeezyMovies.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Constants;
    using PeezyMovies.Core.Contracts;


    public class UsersController : AdminController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userService.AllUsers();

            return this.View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Forget(string userId)
        {
            bool result = await userService.Forget(userId);

            if (result)
                TempData[MessageConstants.SuccessMessage] = "User is forgotten!";
            else
                TempData[MessageConstants.ErrorMessage] = "User is unforgetable!";

            return this.RedirectToAction(nameof(Index));
        }
    }
}
