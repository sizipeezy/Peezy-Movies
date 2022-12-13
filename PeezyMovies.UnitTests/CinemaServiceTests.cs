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
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Threading.Tasks;

    [TestFixture]
    public class CinemaServiceTests
    {
        private IRepository repo;
        private ILogger<CinemaService> logger;
        private IGuard guard;
        private ICinemaService cinemaService;
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
        public async Task ExistsShouldReturnTrue()
        {
            var repo = new Repository(applicationDbContext);
            cinemaService = new CinemaService(repo, guard);

            var testCinema = await cinemaService.Exists(1);

            Assert.That(testCinema, Is.EqualTo(true));
        }

        [Test]
        public async Task ExistsShouldReturnFalse()
        {
            var repo = new Repository(applicationDbContext);
            cinemaService = new CinemaService(repo, guard);

            var testCinema = await cinemaService.Exists(12);

            Assert.False(testCinema);
        }

        [Test]
        public async Task GetAllAsyncShouldSucceed()
        {
            var repo = new Repository(applicationDbContext);
            cinemaService = new CinemaService(repo, guard);

            var result = await cinemaService.GetAllAsync();

            Assert.That(result.Any());
        }

        [Test]
        public async Task AddCinemaAsyncShouldSucceedCreatingCinema()
        {
            //Arrange
            var repo = new Repository(applicationDbContext);
            cinemaService = new CinemaService(repo, guard);

            var testModel = new AddCinemaViewModel()
            {
                Logo = "Test logo",
                Name = "Has a Name",
                Description = "Test Description"
            };

            //Act
            await cinemaService.AddCinemaAsync(testModel);
            var allCinemas = await cinemaService.GetAllAsync();

            //Assert
            Assert.That(allCinemas.Count() > 3);
            Assert.That(allCinemas.Any(x => x.Id == 4));

        }

        [Test]
        public async Task DeleteCinemaAsyncShouldSucceedRemovingCinema()
        {
            //Arrange
            var repo = new Repository(applicationDbContext);
            cinemaService = new CinemaService(repo, guard);

            //Act
            await cinemaService.DeleteCinemaAsync(4);
            //Assert

            Assert.Pass();
        }

        [Test]
        public async Task UpdateCinemaAsyncShouldSucceed()
        {
            var repo = new Repository(applicationDbContext);
            cinemaService = new CinemaService(repo, guard);

            var newCinemaModel = new AddCinemaViewModel()
            {
                Logo = "test",
                Name = "test1",
                Description = "123124",
            };


            await cinemaService.UpdateCinemaAsync(newCinemaModel, 3);

            Assert.Pass();

        }

        [Test]
        public async Task UpdateCinemaAsyncShouldFail()
        {
            var repo = new Repository(applicationDbContext);
            cinemaService = new CinemaService(repo, guard);

            var newCinemaModel = new AddCinemaViewModel()
            {
                Logo = "test",
                Name = "test1",
                Description = "123124",
            };

            var result = cinemaService.UpdateCinemaAsync(newCinemaModel, 672);

            Assert.That(result.IsCompletedSuccessfully == false);

        }
        [Test]
        public async Task GetByIdShouldReturnTrue()
        {
            var repo = new Repository(applicationDbContext);
            cinemaService = new CinemaService(repo, guard);

            var res = cinemaService.GetById(3);

            Assert.That(res != null);
        }


        [Test]
        public async Task GetByIdAsyncShouldFail()
        {
            var repo = new Repository(applicationDbContext);
            cinemaService = new CinemaService(repo, guard);

            var cinemaTest = await cinemaService.GetByIdAsync(1);

            var dbCInema = await repo.GetByIdAsync<Cinema>(421);

            Assert.That(dbCInema == null);
        }

        [Test]
        public async Task GetByIdAsyncShouldSucceed()
        {
          var repo = new Repository(applicationDbContext);
          cinemaService = new CinemaService(repo, guard);

          await repo.SaveChangesAsync();

          var cinemaTest =  await cinemaService.GetByIdAsync(1);

          var dbCInema = await repo.GetByIdAsync<Cinema>(1);

          Assert.That(dbCInema != null);
        }
    }
}
