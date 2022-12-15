namespace PeezyMovies.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Exceptions;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data;
    using PeezyMovies.Infrastructure.Data.Common;
    using System;


    public class ProducerServiceTests
    {
        private IRepository repo;
        private ILogger<ProducerService> logger;
        private IGuard guard;
        private IProducerService producerService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            guard = new Guard();
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("PeezyMovies")
            .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public void EditByIdShouldReturnNullIfThereIsNoProducerWithId()
        {
            var repo = new Repository(applicationDbContext);
            producerService = new ProducerService(repo, guard);

            var fakeProducer = producerService?.EditById(2391);

            Assert.IsTrue(fakeProducer == null);
        }

        [Test]
        public void DeleteProducerAsyncShouldReturnSuccess()
        {
            var repo = new Repository(applicationDbContext);
            producerService = new ProducerService(repo, guard);
            var randomId = new Random().Next(1, 3);

            var fakeProducer = producerService?.DeleteProducerAsync(randomId);

            Assert.That(fakeProducer.IsCompletedSuccessfully);
        }



        [Test]
        public void EditProducerDetailAsyncShouldSucceedUpdate()
        {
            var repo = new Repository(applicationDbContext);
            producerService = new ProducerService(repo, guard);
            var randomId = new Random().Next(1, 3);
            var EditProducerModel = new AddProducerViewModel()
            {
                Id = 5,
                FullName = "Updated test",
                ImageUrl = "https:",
            };

            var fakeProducer = producerService?.EditProducerDetailAsync(EditProducerModel, randomId);

            Assert.That(fakeProducer.IsCompletedSuccessfully);
        }


        [Test]
        public void GetProducerDetailsShouldReturnTaskProducerViewModel()
        {
            var repo = new Repository(applicationDbContext);
            producerService = new ProducerService(repo, guard);

            var randomId = new Random().Next(1, 3);

            var fakeProducer = producerService?.GetProducerDetails(randomId);

            Assert.That(fakeProducer.IsCompleted);
        }


        [Test]
        public void EditByIdShouldReturnTrue()
        {
            var repo = new Repository(applicationDbContext);
            producerService = new ProducerService(repo, guard);
            var randomId = new Random().Next(1, 3);

            var fakeProducer = producerService?.GetById(randomId);

            Assert.IsTrue(fakeProducer != null);
        }


        [Test]
        public void AddProducerAsyncShouldSucceed()
        {
            var repo = new Repository(applicationDbContext);
            producerService = new ProducerService(repo, guard);

            var testProducer = new AddProducerViewModel()
            {
                FullName = "Thank you",
                ImageUrl = "For The Test",
            };

            var result = producerService.AddProducerAsync(testProducer);

            Assert.IsTrue(result.IsCompletedSuccessfully);

        }

        [Test]
        public async Task GetAllAsyncShouldSucceed()
        {
            var repo = new Repository(applicationDbContext);
            producerService = new ProducerService(repo, guard);

            var result = await producerService.GetAllAsync();

            Assert.True(result.Any());
        }

        [Test]
        public void ExistsShouldReturnFalse()
        {
            var repo = new Repository(applicationDbContext);
            producerService = new ProducerService(repo, guard);

            var result = producerService?.Exists(-12);

            Assert.IsFalse(result?.Result);
        }

        [Test]
        public void ExistsShouldReturnTrue()
        {
            var repo = new Repository(applicationDbContext);
            producerService = new ProducerService(repo, guard);

            var result = producerService?.Exists(1);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetByIdAsyncShouldFail()
        {
            var repo = new Repository(applicationDbContext);
            producerService = new ProducerService(repo, guard);

            var producer = producerService.GetById(124123);

            Assert.That(producer == null);
        }

        [Test]
        public void  GetByIdAsyncShouldSucceed()
        {
            var repo = new Repository(applicationDbContext);
            producerService = new ProducerService(repo, guard);

            var producer = producerService.GetById(1);

            Assert.That(producer != null);
        }
    }
}
