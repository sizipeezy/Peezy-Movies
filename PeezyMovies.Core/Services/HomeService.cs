namespace PeezyMovies.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class HomeService : IHomeService
    {
        private readonly IRepository repo;

        public HomeService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<MovieViewModel>> GetLastThreeAsync()
        {
            return await repo.All<Movie>().OrderByDescending(x => x.Id)
           .Take(3)
           .Select(x => new MovieViewModel
           {
               Id = x.Id,
               Director = x.Director,
               ImageUrl = x.ImageUrl,
               Genre = x.Genre.Name,
               Title = x.Title,
               Rating = x.Rating,
               Price = x.Price,
               Cinema = x.Cinema.Name,
               Producer = x.Producer.FullName,
               Description = x.Description,

           }).ToListAsync();
        }
    }
}
