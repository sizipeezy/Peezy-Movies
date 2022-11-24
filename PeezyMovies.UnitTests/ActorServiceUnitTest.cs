namespace PeezyMovies.UnitTests
{
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;

    public class ActorServiceUnitTest
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
                .AddSingleton<IProducerService, ProducerService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedAsync(repo);
        }

        [Test]
        public async Task Test1()
        {
            var service = serviceProvider.GetService<IProducerService>();

            var product = await service.Exists(1);

            Assert.That(product, Is.EqualTo(true));
        }

        private async Task SeedAsync(IRepository repo)
        {
            var product = new Actor()
            {
               
                Bio = "Test Bio 1",
                FullName = "Test Testov 1",
                ImageUrl = "Http"
            };

            var product2 = new Actor()
            {
                
                Bio = "Test Bio 2",
                FullName = "Test Testov 2",
                ImageUrl = "Http"
            };

            var product3 = new Actor()
            {
                Bio = "Test Bio 3",
                FullName = "Test Testov 3",
                ImageUrl = "Http"
            };




            var user = new User()
            {
                Id = "TestId",
                Email = "test@gmail.com",
                EmailConfirmed = true,
                UserName = "TestUsername",
            };


            var category = new Category()
            {
                Name = "TestCategory"
            };

            var recipe = new Movie()
            {
               
                ImageUrl = "https",
                Description = "Test description",
                Price = 51,
                Trailer = "https",
                Rating = 5.9M,
                Director = "Johnnathan",
                Title = "TestRecipe",
            };

            var recipeProducts = new List<Producer>();
          

            await repo.AddAsync(product);
            await repo.AddAsync(product2);
            await repo.AddAsync(product3);

            
            await repo.SaveChangesAsync();
        }
    }
}
