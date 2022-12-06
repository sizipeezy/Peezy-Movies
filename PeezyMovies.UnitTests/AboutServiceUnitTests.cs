namespace PeezyMovies.UnitTests
{
    using Microsoft.Extensions.DependencyInjection;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Threading.Tasks;


    public class AboutServiceUnitTests
    {

        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;


        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IAboutService, AboutService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedAsync(repo);
        }

        [Test]
        public async Task GetActorsPass()
        {
            var service = serviceProvider.GetService<IAboutService>();

            var r = await service.GetActorsInfo();

            Assert.IsNotNull(r);
        }

        [Test]
        public async Task GetActorsShouldSucceed()
        {
            var service = serviceProvider.GetService<IAboutService>();

           var r = await service.GetActorsInfo();

            Assert.That(r.Count() != 0);
        }

        private async Task SeedAsync(IRepository repo)
        {
            var actor1 = new Actor()
            {
                Bio = "This is test bio 1",
                FullName = "Johnathann Fame",
                ImageUrl = "Https",
            };

            var actor2 = new Actor()
            {
                Bio = "This is test bio 2",
                FullName = "Johnathann Fame2",
                ImageUrl = "Https",
            };

            await repo.AddRangeAsync(new List<Actor>()
            {
                actor1,
                actor2,
            });

            await repo.SaveChangesAsync();
        }
    }
}
