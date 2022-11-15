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


    public class ProducerService : IProducerService
    {
        private readonly IRepository repo;

        public ProducerService(IRepository repo)
        {
            this.repo = repo;
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

            producer.FullName = model.FullName;
            producer.ImageUrl = model.ImageUrl;


            repo.Update(producer);
            await repo.SaveChangesAsync();
        }

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

        public Producer GetById(int producerId)
        {
           return this.repo.All<Producer>().FirstOrDefault(x => x.Id == producerId);
           
        }

        public Task<ProducerViewModel> GetByIdAsync(int producerId)
        {
            return this.repo.All<Producer>()
                .Where(x => x.Id == producerId)
                .Select(x => new ProducerViewModel
            {
                FullName = x.FullName,
                Id = x.Id,
                ImageUrl = x.ImageUrl
            }).FirstOrDefaultAsync();
        }

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

            return producer;
        }
    }
}
