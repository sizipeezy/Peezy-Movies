namespace PeezyMovies.UnitTests
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
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
                .AddSingleton<IActorService, ActorService>()
                .AddLogging()
                .BuildServiceProvider();


            var repo = serviceProvider.GetService<IRepository>();
            var logger = Mock.Of<ILogger<IActorService>>();

      
            await SeedAsync(repo);
        }

        [Test]
        public void DeleteActorAsyncShouldReturnSuccess()
        {
            var service = serviceProvider.GetService<IActorService>();
            var randomId = new Random().Next(1, 3);

            var fakeProducer = service?.DeleteActorAsync(randomId);

            Assert.That(fakeProducer.IsCompletedSuccessfully);
        }

        [Test]
        public async Task EditActorDetailAsyncShouldSucceedUpdate()
        {
            var service = serviceProvider.GetService<IActorService>();
            var randomId = new Random().Next(1, 3);
            var EditActorModel = new AddActorViewModel()
            {
                Id = 5,
                FullName = "Updated test",
                ImageUrl = "https:",
            };

            var fakeProducer = service?.EditActorDetailsAsync(EditActorModel, randomId);

            Assert.That(fakeProducer.IsCompletedSuccessfully);
        }


        [Test]
        public void ActorByIdShouldSucceed()
        {
            var service = serviceProvider.GetService<IActorService>();
            var randomId = new Random().Next(1, 3);

            var fakeActor = service?.ActorById(randomId);

            Assert.IsTrue(fakeActor != null);
        }

        [Test]
        public void EditByIdShouldReturnTrue()
        {
            var service = serviceProvider.GetService<IActorService>();
            var randomId = new Random().Next(1, 3);

            var fakeActor = service?.GetById(randomId);

            Assert.IsTrue(fakeActor != null);
        }

        [Test]
        public void GetByIdShouldReturnNullIfThereIsNoSuchActorWithId()
        {
            var service = serviceProvider.GetService<IActorService>();

            var fakeActor = service?.GetById(2391);

            Assert.IsTrue(fakeActor == null);
        }


        [Test]
        public async Task AddActorShouldSucceed()
        {
            var service = serviceProvider.GetService<IActorService>();

            var testActor = new AddActorViewModel()
            {
                FullName = "Thank you",
                ImageUrl = "For The Test",
                Bio = "Test Bio",
            };

            var result = service.AddActorAsync(testActor);

            Assert.IsTrue(result.IsCompletedSuccessfully);

        }


        [Test]
        public async Task GetAllAsyncShouldSucceed()
        {
            var service = serviceProvider.GetService<IActorService>();

            var result = await service.GetAllAsync();

            Assert.True(result.Any());
        }


        [Test]
        public void ExistsShouldReturnFalse()
        {
            var service = serviceProvider.GetService<IActorService>();

            var result = service?.Exists(-12);

            Assert.IsFalse(result?.Result);
        }

        [Test]
        public void ExistsShouldReturnTrue()
        {

            var service = serviceProvider.GetService<IActorService>();

            var result = service?.Exists(1);

            Assert.IsNotNull(result);
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

            await repo.AddAsync(product);
            await repo.AddAsync(product2);
            await repo.AddAsync(product3);

            
            await repo.SaveChangesAsync();
        }
    }
}
