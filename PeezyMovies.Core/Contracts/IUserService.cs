namespace PeezyMovies.Core.Contracts
{
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IUserService
    {
        Task<bool> Forget(string userId);

        Task<IEnumerable<User>> AllUsers();
    }
}
