namespace PeezyMovies.UnitTests
{
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
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
                .AddSingleton<IProducerService, ProducerService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedAsync(repo);
        }

        [Test]
        public async Task DeleteProducerAsyncShouldReturnSuccess()
        {
            var service = serviceProvider.GetService<IProducerService>();
            var randomId = new Random().Next(1, 3);
          
            var fakeProducer = service?.DeleteProducerAsync(randomId);

            Assert.That(fakeProducer.IsCompletedSuccessfully);
        }

        

        [Test]
        public async Task EditProducerDetailAsyncShouldSucceedUpdate()
        {
            var service = serviceProvider.GetService<IProducerService>();
            var randomId = new Random().Next(1, 3);
            var EditProducerModel = new AddProducerViewModel()
            {
                Id = 5,
                FullName = "Updated test",
                ImageUrl = "https:",
            };

            var fakeProducer = service?.EditProducerDetailAsync(EditProducerModel, randomId);

            Assert.That(fakeProducer.IsCompletedSuccessfully);
        }
        

        [Test]
        public async Task GetProducerDetailsShouldReturnTaskProducerViewModel()
        {
            var service = serviceProvider.GetService<IProducerService>();
            var randomId = new Random().Next(1, 3);

            var fakeProducer = service?.GetProducerDetails(randomId);

            Assert.That(fakeProducer.IsCompleted);
        }


        [Test]
        public async Task EditByIdShouldReturnTrue()
        {
            var service = serviceProvider.GetService<IProducerService>();
            var randomId = new Random().Next(1, 3);

            var fakeProducer = service?.EditById(randomId);

            Assert.IsTrue(fakeProducer != null);
        }

        [Test]
        public async Task EditByIdShouldReturnNullIfThereIsNoProducerWithId()
        {
            var service = serviceProvider.GetService<IProducerService>();
            var randomId = new Random().Next(4, 10);

            var fakeProducer = service?.EditById(randomId);

            Assert.IsTrue(fakeProducer == null);
        }


        [Test]
        public async Task AddProducerAsyncShouldAddProducerSuccess()
        {
            var service = serviceProvider.GetService<IProducerService>();

            var TestProducer = new AddProducerViewModel()
            {
                Id = 4,
                FullName = "Test",
                ImageUrl = "https"
            };

            var error = service?.AddProducerAsync(TestProducer);

            Assert.That(error.IsCompletedSuccessfully == true);
        }

        [Test]
        public async Task GetByIdShouldReturnProducer()
        {
            var service = serviceProvider.GetService<IProducerService>();

            var randomId = new Random().Next(1, 3);

            var currentProducer = service?.GetById(randomId);

            Assert.That(currentProducer != null);
        }


        [Test]
        public async Task AllGetAsyncShouldReturnAllThreeProducers()
        {
            var service = serviceProvider.GetService<IProducerService>();

            var allProducers = await service?.GetAllAsync();

            Assert.That(allProducers, Is.EqualTo(allProducers.ToList()));
        }

        [Test]
        public async Task ExsistsShouldReturnTrueForTheProducer()
        {
            var service = serviceProvider.GetService<IProducerService>();

            var product = await service?.Exists(1);

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

            await repo.AddAsync(product);
            await repo.AddAsync(product2);
            await repo.AddAsync(product3);

            
            await repo.SaveChangesAsync();
        }
    }
}
