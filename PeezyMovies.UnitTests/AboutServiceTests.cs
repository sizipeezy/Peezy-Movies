namespace PeezyMovies.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using PeezyMovies.Core.Services;

    public class AboutServiceTests
    {
        private IRepository repo;
        private IAboutService aboutService;
        private ApplicationDbContext applicationDbContext;

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
        public async Task GetActorsPass()
        {
            var repo = new Repository(applicationDbContext);
            aboutService = new AboutService(repo);

            var r = await aboutService.GetActorsInfo();

            Assert.IsNotNull(r);
        }

        [Test]
        public async Task GetActorsShouldSucceed()
        {
            var repo = new Repository(applicationDbContext);
            aboutService = new AboutService(repo);

            var r = await aboutService.GetActorsInfo();

            Assert.That(r.Count() != 0);
        }
    }
}
