namespace PeezyMovies.UnitTests
{
    using Microsoft.Extensions.DependencyInjection;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public class CinemaServiceUnitTests
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
                .AddSingleton<ICinemaService, CinemaService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedAsync(repo);
        }

        [Test]
        public async Task GetByIdAsyncShouldSucceed()
        {
            var service = serviceProvider.GetService<ICinemaService>();

            var res = await service.GetByIdAsync(3);

            Assert.That(res != null);
        }

        [Test]
        public async Task GetByIdShouldReturnTrue()
        {
            var service = serviceProvider.GetService<ICinemaService>();

            var res = service.GetById(3);

            Assert.That(res != null);
        }

        [Test]
        public async Task UpdateCinemaAsyncShouldFail()
        {
            var service = serviceProvider.GetService<ICinemaService>();


            var newCinemaModel = new AddCinemaViewModel()
            {
                Logo = "test",
                Name = "test1",
                Description = "123124",
            };

            var result = service.UpdateCinemaAsync(newCinemaModel, 672);

            Assert.That(result.IsCompletedSuccessfully == false);

        }

        [Test]
        public async Task UpdateCinemaAsyncShouldSucceed()
        {
            var service = serviceProvider.GetService<ICinemaService>();


            var newCinemaModel = new AddCinemaViewModel()
            {
                Logo = "test",
                Name = "test1",
                Description = "123124",
            };


            await service.UpdateCinemaAsync(newCinemaModel, 3);

            Assert.Pass();

        }

        [Test]
        public async Task DeleteCinemaAsyncShouldSucceedRemovingCinema()
        {
            //Arrange
            var service = serviceProvider.GetService<ICinemaService>();


            //Act
            await service.DeleteCinemaAsync(4);
            //Assert

            Assert.Pass();
        }

        [Test]
        public async Task AddCinemaAsyncShouldSucceedCreatingCinema()
        {
            //Arrange
            var service = serviceProvider.GetService<ICinemaService>();
            var testModel = new AddCinemaViewModel()
            {
                Logo = "Test logo",
                Name = "Has a Name",
                Description = "Test Description"
            };

            //Act
            await service.AddCinemaAsync(testModel);
            var allCinemas = await service.GetAllAsync();


            //Assert
            Assert.That(allCinemas.Count() > 3);
            Assert.That(allCinemas.Any(x => x.Id == 4));

        }

        [Test]
        public async Task GetAllAsyncShouldSucceed()
        {
            var service = serviceProvider.GetService<ICinemaService>();

            var result = await service.GetAllAsync();

            Assert.That(result.Any());
        }

        [Test]
        public async Task ExistsShouldReturnFalse()
        {
            var service = serviceProvider.GetService<ICinemaService>();

            var testCinema = await service.Exists(12);

            Assert.False(testCinema);
        }

        [Test]
        public async Task ExistsShouldReturnTrue()
        {
            var service = serviceProvider.GetService<ICinemaService>();

            var testCinema = await service.Exists(1);

            Assert.That(testCinema, Is.EqualTo(true));
        }

        private async Task SeedAsync(IRepository repo)
        {
            var cinema1 = new Cinema()
            {
                Name = "Test 1",
                Logo = "https",
                Description = "Test Description 1",

            };

            var cinema2 = new Cinema()
            {
                Name = "Test 2",
                Logo = "https",
                Description = "Test Description 2",

            };


            var cinema3 = new Cinema()
            {
                Name = "Test 3",
                Logo = "https",
                Description = "Test Description 3",

            };
            await repo.AddRangeAsync(new List<Cinema>()
            {
                cinema1, cinema2, cinema3
            });

            await repo.SaveChangesAsync();
        }
    }
}
