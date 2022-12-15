namespace PeezyMovies.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data;
    using PeezyMovies.Infrastructure.Data.Common;
    using System;

    public class ContactServiceTests
    {
        private IRepository repo;
        private IContactService contactService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("PeezyMovies")
            .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public void SendEmailShouldSucceed()
        {
            var repo = new Repository(applicationDbContext);
            contactService = new ContactService(repo);

            var testModel = new ContactFormViewModel()
            {
                Email = "Test@abv.bg",
                Content = "hello test how are you today",
                Name = "Shawn Mendes",
                Subject = "Habibi",

            };

            Assert.Pass(contactService.SendEmail(testModel).ToString());
        }


        [Test]
        public void SendEmailShouldThrowNullException()
        {
            var repo = new Repository(applicationDbContext);
            contactService = new ContactService(repo);

            var result = contactService.SendEmail(null);

            Assert.ThrowsAsync<NullReferenceException>(async () => await result);
        }

        [Test]
        public void SendEmailShouldFail()
        {

            var repo = new Repository(applicationDbContext);
            contactService = new ContactService(repo);

            var testModel = new ContactFormViewModel()
            {
                Email = "Test@email.bg",
                Content = " hello test",
                Name = "Shawn Mendes",
                Subject = "Habibi",
            };

            var result = contactService.SendEmail(testModel);

            Assert.That(result.IsCompletedSuccessfully == false);
        }

    }
}
