namespace PeezyMovies.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Exceptions;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data;
    using PeezyMovies.Infrastructure.Data.Common;
    using System;


    public class ActorServiceTests
    {
        private IRepository repo;
        private ILogger<ActorService> logger;
        private IGuard guard;
        private IActorService actorService;
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
        public void DeleteActorAsyncShouldReturnSuccess()
        {
            var repo = new Repository(applicationDbContext);
            actorService = new ActorService(repo, logger, guard);

            var randomId = new Random().Next(1, 3);

            var fakeProducer = actorService?.DeleteActorAsync(randomId);

            Assert.That(fakeProducer.IsCompletedSuccessfully);
        }

        [Test]
        public async Task EditActorDetailAsyncShouldSucceedUpdate()
        {
            var repo = new Repository(applicationDbContext);
            actorService = new ActorService(repo, logger, guard);

            var randomId = new Random().Next(1, 3);

            var EditActorModel = new AddActorViewModel()
            {
                Id = 5,
                FullName = "Updated test",
                ImageUrl = "https:",
            };

            var fakeProducer = actorService?.EditActorDetailsAsync(EditActorModel, randomId);

            Assert.That(fakeProducer.IsCompletedSuccessfully);
        }



        [Test]
        public void EditByIdShouldReturnTrue()
        {
            var repo = new Repository(applicationDbContext);
            actorService = new ActorService(repo, logger, guard);

            var randomId = new Random().Next(1, 3);

            var fakeActor = actorService?.GetById(randomId);

            Assert.IsTrue(fakeActor != null);
        }

        [Test]
        public void GetByIdShouldReturnNullIfThereIsNoSuchActorWithId()
        {
            var repo = new Repository(applicationDbContext);
            actorService = new ActorService(repo, logger, guard);

            var fakeActor = actorService?.GetById(2391);

            Assert.IsTrue(fakeActor == null);
        }


        [Test]
        public async Task AddActorShouldSucceed()
        {

            var repo = new Repository(applicationDbContext);
            actorService = new ActorService(repo, logger, guard);

            var testActor = new AddActorViewModel()
            {
                FullName = "Thank you",
                ImageUrl = "For The Test",
                Bio = "Test Bio",
            };

            var result = actorService.AddActorAsync(testActor);

            Assert.IsTrue(result.IsCompletedSuccessfully);
        }


        [Test]
        public async Task GetAllAsyncShouldSucceed()
        {

            var repo = new Repository(applicationDbContext);
            actorService = new ActorService(repo, logger, guard);

            var result = await actorService.GetAllAsync();

            Assert.True(result.Any());
        }


        [Test]
        public void ExistsShouldReturnFalse()
        {
            var repo = new Repository(applicationDbContext);
            actorService = new ActorService(repo, logger, guard);

            var result = actorService?.Exists(-12);

            Assert.IsFalse(result?.Result);
        }


        [Test]
        public async Task ActorByIdFails()
        {
            var repo = new Repository(applicationDbContext);
            actorService = new ActorService(repo, logger, guard);

            var actor = await actorService.ActorById(13281);

            Assert.IsNull(actor);
        }

        [Test]
        public void ActorByIdSucceed()
        {
            var repo = new Repository(applicationDbContext);
            actorService = new ActorService(repo, logger, guard);

            var actor = actorService.ActorById(1);

            Assert.That(actor != null);
        }
    }
}
