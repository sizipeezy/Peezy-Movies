namespace PeezyMovies.UnitTests
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Moq;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
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
