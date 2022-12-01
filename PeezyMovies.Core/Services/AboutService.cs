namespace PeezyMovies.Core.Services
{
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public class AboutService : IAboutService
    {
        private readonly IRepository repo;

        public AboutService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Actor>> GetActorsInfo()
        {
            var list = this.repo.All<Actor>().ToList();
            return list;
        }
    }
}
