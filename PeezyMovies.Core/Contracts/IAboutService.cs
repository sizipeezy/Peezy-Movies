namespace PeezyMovies.Core.Contracts
{
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IAboutService 
    {
        Task<IEnumerable<Actor>> GetActorsInfo();
    }
}
