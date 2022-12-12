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


    public class ProducerService : IProducerService
    {
        private readonly IRepository repo;
        private readonly IGuard guard;
        public ProducerService(IRepository repo, IGuard guard)
        {
            this.repo = repo;
            this.guard = guard;
        }

        public async Task AddProducerAsync(AddProducerViewModel model)
        {
            var producer = new Producer()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,

            };

            await repo.AddAsync(producer);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteProducerAsync(int producerId)
        {
            var producer = await repo.All<Producer>().FirstOrDefaultAsync(x => x.Id == producerId);
            if (producer != null)
            {
                repo.Delete(producer);
            }

            await repo.SaveChangesAsync();
        }

        public AddProducerViewModel EditById(int producerId)
        {
            guard.AgainstNull(producerId, "Producer cannot be found");

            return repo.All<Producer>()
                .Where(x => x.Id == producerId)
                .Select(x => new AddProducerViewModel
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    ImageUrl = x.ImageUrl,
                }).FirstOrDefault();
        }

        public async Task EditProducerDetailAsync(AddProducerViewModel model, int producerId)
        {
            var producer = await repo.AllReadonly<Producer>().FirstOrDefaultAsync(x => x.Id == producerId);

            guard.AgainstNull(producer, "Producer cannot be found");

            producer.FullName = model.FullName;
            producer.ImageUrl = model.ImageUrl;


            repo.Update(producer);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id) => 
            await repo.AllReadonly<Producer>().AnyAsync(x => x.Id == id);

        public async Task<IEnumerable<ProducerViewModel>> GetAllAsync()
        {
            var allProducers = await repo.AllReadonly<Producer>().Select(x => new ProducerViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                ImageUrl = x.ImageUrl,
            }).ToListAsync();

            return allProducers;
        }

        public Producer GetById(int producerId) => 
            this.repo.All<Producer>().FirstOrDefault(x => x.Id == producerId);
           

        public async Task<ProducerViewModel> GetProducerDetails(int producerId)
        {
            var producer = await this.repo.All<Producer>()
                .Where(x => x.Id == producerId)
                .Select(x => new ProducerViewModel
            {
                FullName = x.FullName,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
            }).FirstOrDefaultAsync();

            guard.AgainstNull(producer, "Producer cannot be found");

            return producer;
        }
    }
}
