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

    public class MovieServiceTests
    {
        private IRepository repo;
        private ILogger<MovieService> logger;
        private IGuard guard;
        private IMovieService movieService;
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
        public async Task GetAllAsyncShouldReturnSuccessfully()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var result = await movieService.GetAllAsync();

            Assert.That(result.Count(), Is.Not.EqualTo(null));
        }


        [Test]
        public async Task MovieForViewReturnsMovieViewModel()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var result = movieService.MovieForView(1);

            Assert.That(result != null);
        }


        [Test]
        public async Task DeleteMovieSucceed()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var result = await movieService.DeleteMovie(1);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExsistsMovie()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var testCinema = await movieService.Exists(1);

            Assert.That(testCinema, Is.EqualTo(true));
        }


        [Test]
        public async Task GetGenresAsyncShouldSucceed()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var result = await movieService.GetGenresAsync();

            Assert.That(result.Any());
        }

        [Test]
        public void GetWatchedAsync()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var result = movieService.GetWatchedAsync(Guid.NewGuid().ToString());

            Assert.IsNotNull(result);
        }

        [Test]
        public void AddMovieToCollectionAsyncShouldFail()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var expected = movieService.AddMovieToCollectionAsync(Guid.NewGuid().ToString(), 1);

            Assert.That(expected.IsCompletedSuccessfully);
        }

        [Test]
        public void EditMovieSuccess()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var testMovie = new EditMovieViewModel()
            {
                Director = "Test",
                Description = "Test description 3",
                ImageUrl = "https.",
                Title = "The Title 21",
                Rating = 8.0M,
                Price = 15.77M,
            };

            var result = movieService.EditMovie(1, testMovie);

            Assert.IsNotNull(result);
            Assert.That(result.IsCompleted);

        }



        [Test]
        public void GenresNamesAsStrings()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var result = movieService.GenresNamesAsStrings();

            Assert.That(result.Count() != 0);
        }

        [Test]
        public async Task AddMovieAsyncShouldFail()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var result = movieService.AddMovieAsync(null);

            Assert.ThrowsAsync<NullReferenceException>(async () => await result);
        }


        [Test]
        public void RemoveFromCollectionAsync()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var result = movieService.RemoveFromCollectionAsync(Guid.NewGuid().ToString(), 1);

            Assert.That(result.IsCompletedSuccessfully);
        }


        [Test]
        public async Task GetProducersAsyncShouldSucceed()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var result = await movieService.GetProducersAsync();

            Assert.That(result.Any());
        }


        [Test]
        public async Task GetCinemasAsyncShouldSucceed()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var result = await movieService.GetCinemasAsync();

            Assert.That(result.Any());
        }

        [Test]
        public async Task GetActorsDropDown()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo, logger, guard);

            var result = await movieService.GetActorsDropDown();

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetByIdReturnNullIfIdDoesntExsists()
        {
            var repo = new Repository(applicationDbContext);
            movieService = new MovieService(repo,logger, guard);

            var movieTest = await movieService.GetMovieByIdAsync(1);

            Assert.That(movieTest == null);
        }
    }
}
