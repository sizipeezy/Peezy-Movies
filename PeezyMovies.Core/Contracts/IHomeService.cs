namespace PeezyMovies.Core.Contracts
{
    using PeezyMovies.Core.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IHomeService
    {
        Task<IEnumerable<MovieViewModel>> GetLastThreeAsync();
    }
}
