namespace PeezyMovies.UnitTests
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Moq;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;


    public class MoviesServiceUnitTests
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
                .AddSingleton<IMovieService, MovieService>()
                .AddLogging()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
            var logger = Mock.Of<ILogger<IMovieService>>();


            await SeedAsync(repo);
        }

        [Test]
        public async Task GetActorsDropDown()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = await service.GetActorsDropDown();

            Assert.IsNotNull(result);
        }


        [Test]
        public async Task GetProducersAsyncShouldSucceed()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = await service.GetProducersAsync();

            Assert.That(result.Any());
        }


        [Test]
        public async Task GetCinemasAsyncShouldSucceed()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = await service.GetCinemasAsync();

            Assert.That(result.Any());
        }


        [Test]
        public async Task GetGenresAsyncShouldSucceed()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = await service.GetGenresAsync();

            Assert.That(result.Any());
        }

        [Test]
        public void GetWatchedAsync()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = service.GetWatchedAsync(Guid.NewGuid().ToString());

            Assert.IsNotNull(result);
        }

        [Test]
        public void RemoveFromCollectionAsync()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = service.RemoveFromCollectionAsync(Guid.NewGuid().ToString(), 1);

            Assert.That(result.IsCompletedSuccessfully);
        }

        [Test]
        public void AddMovieToCollectionAsyncShouldFail()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var expected = service.AddMovieToCollectionAsync(Guid.NewGuid().ToString(), 1);

            Assert.That(expected.IsCompletedSuccessfully);
        }

        [Test]
        public void EditMovieSuccess()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var testMovie = new EditMovieViewModel()
            {
                Director = "Test",
                Description = "Test description 3",
                ImageUrl = "https.",
                Title = "The Title 21",
                Rating = 8.0M,
                Price = 15.77M,
            };

            var result = service.EditMovie(1, testMovie);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsCompletedSuccessfully);
            Assert.That(result.IsCompleted);

        }

        [Test]
        public async Task GetMovieByIdAsync()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = await service.GetMovieByIdAsync(1);

            Assert.That(result is not null);
        }

        [Test]
        public void GenresNamesAsStrings()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = service.GenresNamesAsStrings();

            Assert.That(result.Count() != 0);
        }

        [Test]
        public async Task AddMovieAsyncShouldFail()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = service.AddMovieAsync(null);

            Assert.ThrowsAsync<NullReferenceException>(async() => await result);
        }


        [Test]
        public async Task GetAllAsyncShouldReturnSuccessfully()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = await service.GetAllAsync();

            Assert.That(result.Any());
        }


        [Test]
        public async Task MovieForViewReturnsMovieViewModel()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = service.MovieForView(1);

            Assert.That(result != null);
        }


        [Test]
        public async Task DeleteMovieSucceed()
        {
            var service = serviceProvider.GetService<IMovieService>();

            var result = await service.DeleteMovie(1);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task  ExsistsMovie()
        {
            var service = serviceProvider.GetService<IMovieService>();

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


            var actor = new Actor()
            {
                Bio = "Test Bio 3",
                FullName = "Test Testov 3",
                ImageUrl = "Http"
            };

            var producer3 = new Producer()
            {

                FullName = "Johnathann Fame3",
                ImageUrl = "Https",

            };

            var user = new User()
            {
                Id = "TestId",
                Email = "test@gmail.com",
                EmailConfirmed = true,
                UserName = "TestUsername",
            };

           

            var genre = new Genre()
            {
                Name = "Test"
            };

            var testMovie1 = new Movie()
            {
                Director = "Test",
                Description = "Test description",
                ImageUrl = "https.",
                Title = "The Title",
                Rating = 5.0M,
                Price = 25.77M,
                IsDeleted = false,
                Trailer = "https",
                Id = 1,
                Genre = genre,
                GenreId = genre.Id,
                Cinema = cinema1,
                CinemaId = cinema1.Id,
                Producer = producer3,
                ProducerId = producer3.Id,
              
            };

            //var actorMovies = new ActorMovie()
            //{
            //    ActorId = actor.Id,
            //    MovieId = testMovie1.Id,
            //};

            await repo.AddAsync(cinema1);
            await repo.AddAsync(actor);
            await repo.AddAsync(producer3);
            await repo.AddAsync(user);
            await repo.AddAsync(genre);
            //await repo.AddAsync(actorMovies);
            await repo.AddAsync(testMovie1);
            await repo.SaveChangesAsync();
        }
    }
}
