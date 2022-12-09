namespace PeezyMovies.UnitTests
{
    using Microsoft.Extensions.DependencyInjection;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data.Common;
    using System.Threading.Tasks;


    public class ContactServiceUnitTests
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
                .AddSingleton<IContactService, ContactService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
        }

        [Test]
        public void SendEmailShouldSucceed()
        {
            var service = serviceProvider.GetService<IContactService>();

            var testModel = new ContactFormViewModel()
            {
                Email = "Test@abv.bg",
                Content = "hello test how are you today",
                Name = "Shawn Mendes",
                Subject = "Habibi",

            };
                  
            Assert.Pass(service.SendEmail(testModel).ToString());
        }


        [Test]
        public void SendEmailShouldThrowNullException()
        {
            var service = serviceProvider.GetService<IContactService>();


            var result = service.SendEmail(null);

            Assert.ThrowsAsync<NullReferenceException>(async () => await result);
        }

        [Test]
        public void SendEmailShouldFail()
        {
            var service = serviceProvider.GetService<IContactService>();

            var testModel = new ContactFormViewModel()
            {
                Email = "Test@email.bg",
                Content =" hello test",
                Name = "Shawn Mendes",
                Subject = "Habibi",
            };

           var result =  service.SendEmail(testModel);

            Assert.That(result.IsCompletedSuccessfully == false);
        }

    }
}
