namespace PeezyMovies.Core.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Infrastructure.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;

        public UserService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IEnumerable<User>> AllUsers() => 
            await this.userManager.Users.Where(x => x.IsActive == true).ToListAsync();

        public async Task<bool> Forget(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            user.PhoneNumber = null;
            user.Email = null;
            user.NormalizedEmail = null;
            user.NormalizedUserName = null;
            user.PasswordHash = null;
            user.IsActive = false;
            user.UserName = $"forgottenUser-{DateTime.Now.Ticks}";

            var result = await userManager.UpdateAsync(user);

            return result.Succeeded;
        }
    }
}
