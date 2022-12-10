namespace PeezyMovies.Core.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly IRepository repo;

        public UserService(UserManager<User> userManager, IRepository repo)
        {
            this.userManager = userManager;
            this.repo = repo;
        }

        public async Task<IEnumerable<User>> AllUsers() => 
            await this.userManager.Users.ToListAsync();

        public Task<bool> Forget(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
