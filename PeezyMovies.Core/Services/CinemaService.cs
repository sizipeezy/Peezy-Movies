namespace PeezyMovies.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Exceptions;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class CinemaService : ICinemaService
    {
        private readonly IRepository repo;
        private readonly IGuard guard;
        public CinemaService(IRepository repo, IGuard guard)
        {
            this.repo = repo;
            this.guard = guard;
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

            guard.AgainstNull(cinema, "Cinema cannot be found");

            if ( cinema != null)
            {
                repo.Delete(cinema);
            }

            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id) => 
            await repo.AllReadonly<Cinema>().AnyAsync(x => x.Id == id);

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

        public AddCinemaViewModel GetById(int cinemaId)
        {
            guard.AgainstNull(cinemaId, "Cinema cannot be found");

            return repo.All<Cinema>().Where(x => x.Id == cinemaId)
              .Select(x => new AddCinemaViewModel
              {
                  Id = x.Id,
                  Description = x.Description,
                  Logo = x.Logo,
                  Name = x.Name,
              }).FirstOrDefault();
        }

        public Task<CinemaViewModel> GetByIdAsync(int cinemaId)
        {

            guard.AgainstNull(cinemaId, "Cinema cannot be found");

            return repo.All<Cinema>().Select(x => new CinemaViewModel
            {
                Id = x.Id,
                Description =x.Description,
                Logo = x.Logo,
                Name = x.Name 
            }).FirstOrDefaultAsync(x => x.Id == cinemaId);
        }

        public async Task UpdateCinemaAsync(AddCinemaViewModel model, int cinemaId)
        {
            guard.AgainstNull(cinemaId, "Cinema cannot be found");

            var cinema = await repo.All<Cinema>().FirstOrDefaultAsync(x => x.Id == cinemaId);

            cinema.Description = model.Description;
            cinema.Logo = model.Logo;
            cinema.Name = model.Name;

           await repo.SaveChangesAsync();
        }
    }
}
