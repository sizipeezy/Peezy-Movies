using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeezyMovies.Infrastructure.Data.Models;

namespace PeezyMovies.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        private readonly UserManager<User> userManager;

        public UsersController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this.userManager.Users.ToListAsync();

            return this.View(users);
        }
    }
}
