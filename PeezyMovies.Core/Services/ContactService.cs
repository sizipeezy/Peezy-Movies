namespace PeezyMovies.Core.Services
{
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
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
            var contact = new Contact()
            {
                Email = model.Email,
                Message = model.Content,
                Name = model.Name,
                Subject = model.Subject,
            };

            await repo.AddAsync(contact);
            await repo.SaveChangesAsync();

        }
    }
}
