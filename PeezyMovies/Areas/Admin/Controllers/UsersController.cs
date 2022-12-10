using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeezyMovies.Core.Contracts;
using PeezyMovies.Infrastructure.Data.Models;

namespace PeezyMovies.Areas.Admin.Controllers
{
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

        public async Task<IActionResult> Forget()
        {
            return this.View();
        }
    }
}
