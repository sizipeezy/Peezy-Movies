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
    using System.Linq;
    using System.Threading.Tasks;


    public class ProducerServiceUnitTests
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
        public void GetProducerDetailsShouldReturnTaskProducerViewModel()
        {
            var service = serviceProvider.GetService<IProducerService>();
            var randomId = new Random().Next(1, 3);

            var fakeProducer = service?.GetProducerDetails(randomId);

            Assert.That(fakeProducer.IsCompleted);
        }


        [Test]
        public void EditByIdShouldReturnTrue()
        {
            var service = serviceProvider.GetService<IProducerService>();
            var randomId = new Random().Next(1, 3);

            var fakeProducer = service?.GetById(randomId);

            Assert.IsTrue(fakeProducer != null);
        }

        [Test]
        public void EditByIdShouldReturnNullIfThereIsNoProducerWithId()
        {
            var service = serviceProvider.GetService<IProducerService>();

            var fakeProducer = service?.EditById(2391);

            Assert.IsTrue(fakeProducer == null);
        }



        [Test]
        public async Task AddProducerAsyncShouldSucceed()
        {
            var service = serviceProvider.GetService<IProducerService>();

            var testProducer = new AddProducerViewModel()
            {
                FullName = "Thank you",
                ImageUrl = "For The Test",
            };

            var result = service.AddProducerAsync(testProducer);

            Assert.IsTrue(result.IsCompletedSuccessfully);
         
        }

        [Test]
        public async Task GetAllAsyncShouldSucceed()
        {
            var service = serviceProvider.GetService<IProducerService>();

            var result = await service.GetAllAsync();

            Assert.True(result.Any());
        }

        [Test]
        public void ExistsShouldReturnFalse()
        {
            var service = serviceProvider.GetService<IProducerService>();

            var result = service?.Exists(-12);

            Assert.IsFalse(result?.Result);
        }

        [Test]
        public void ExistsShouldReturnTrue()
        {
           
            var service = serviceProvider.GetService<IProducerService>();

            var result = service?.Exists(1);

            Assert.IsNotNull(result);
        }

        private async Task SeedAsync(IRepository repo)
        {
            var movie1 = new Movie()
            {
                Director = "Test",
                Price = 23.42M,
                Description = "Test Description",
                Rating = 5.9M,
                Title = "Test Title",
                Trailer = "Https",
                ImageUrl = "Https",
                ProducerId = 1,
            };


            var producer1 = new Producer()
            {
             
                FullName = "Johnathann Fame",
                ImageUrl = "Https",

            };

            var producer2 = new Producer()
            {

                FullName = "Johnathann Fame2",
                ImageUrl = "Https",

            };

            var producer3 = new Producer()
            {

                FullName = "Johnathann Fame3",
                ImageUrl = "Https",

            };

            await repo.AddRangeAsync(new List<Producer>()
            {
               producer1,
               producer2,
               producer3
            });

            await repo.SaveChangesAsync();
        }
    }
}
