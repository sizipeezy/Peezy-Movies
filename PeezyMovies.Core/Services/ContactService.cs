namespace PeezyMovies.Core.Services
{
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using SendGrid.Helpers.Mail;
    using SendGrid;
    using System.Threading.Tasks;


    public class ContactService : IContactService
    {
        private readonly IRepository repo;

        public ContactService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task SendEmail(ContactFormViewModel model)
        {
            var appiKey = WebAppDataConstants.ApiKey;
            var client = new SendGridClient(appiKey);
            var from = new EmailAddress(model.Email, model.Name);
            var subject = model.Subject;
            var to = new EmailAddress("kaynewestsouth@gmail.com", "Example User");
            var plainTextContent = model.Content;
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            await this.repo.SaveChangesAsync();

        }
    }
}
