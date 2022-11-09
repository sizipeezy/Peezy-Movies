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


    public class CinemaService : ICinemaService
    {
        private readonly IRepository repo;

        public CinemaService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddCinemaAsync(AddCinemaViewModel model)
        {
            var cinema = new Cinema()
            {
                Name = model.Name,
                Description = model.Description,
                Logo = model.Logo,

            };

            await repo.AddAsync(cinema);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteCinemaAsync(int cinemaId)
        {
            var cinema = await repo.All<Cinema>().FirstOrDefaultAsync(x => x.Id == cinemaId);
            if( cinema != null)
            {
                repo.Delete(cinema);
            }

            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<CinemaViewModel>> GetAllAsync()
        {
            var cinemas = await repo.All<Cinema>().Select(x => new CinemaViewModel
            {
                Description = x.Description,
                Logo = x.Logo,
                Name = x.Name,
                Id = x.Id,
            }).ToListAsync();

            return cinemas;
        }

        public AddCinemaViewModel GetById(int movieId)
        {
            return repo.All<Cinema>().Where(x => x.Id == movieId)
              .Select(x => new AddCinemaViewModel
              {
                  Id = x.Id,
                  Description = x.Description,
                  Logo = x.Logo,
                  Name = x.Name,
              }).FirstOrDefault();
        }

        public async Task UpdateCinemaAsync(AddCinemaViewModel model, int cinemaId)
        {
            var cinema = await repo.All<Cinema>().FirstOrDefaultAsync(x => x.Id == cinemaId);

            cinema.Description = model.Description;
            cinema.Logo = model.Logo;
            cinema.Name = model.Name;

           await repo.SaveChangesAsync();
        }
    }
}
