namespace PeezyMovies.UnitTests
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;

    public class UserServiceTests
    {
        private IRepository repo;
        private IUserService userService;
        private ApplicationDbContext applicationDbContext;
        private readonly UserManager<User> userManager;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("PeezyMovies")
            .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public void ForgetActionIsNullWithInvalidGuid()
        {
            var repo = new Repository(applicationDbContext);
            userService = new UserService(userManager);

            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@gmail.com",
                EmailConfirmed = true,
                UserName = "TestUsername",
                PhoneNumber = "089847218",
                PasswordHash = "NewHashSetajdqjd",
                IsActive = true
            };

            var result = userService.Forget(user.Id);

            Assert.That(result.IsCompleted);
        }

        [Test]
        public void AssertThatAllUsersReturnsNotNullResult()
        {
            var repo = new Repository(applicationDbContext);
            userService = new UserService(userManager);

            var result = userService.AllUsers();

            Assert.That(result != null);
        }
    }
}
