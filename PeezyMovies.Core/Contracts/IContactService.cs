namespace PeezyMovies.Core.Contracts
{
    using PeezyMovies.Core.Models;
    using System.Threading.Tasks;


    public interface IContactService
    {
        Task SendEmail(ContactFormViewModel model);
    }
}
