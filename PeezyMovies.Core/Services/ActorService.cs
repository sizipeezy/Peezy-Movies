namespace PeezyMovies.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ActorService : IActorService
    {
        private readonly IRepository repo;
        private readonly ILogger logger;

        public ActorService(IRepository repo, ILogger<ActorService> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        public Task<AddActorViewModel> ActorById(int actorId)
        {
            return repo.All<Actor>()
               .Where(x => x.Id == actorId)
               .Select(x => new AddActorViewModel
               {
                   Id = x.Id,
                   Bio = x.Bio,
                   FullName = x.FullName,
                   ImageUrl = x.ImageUrl,
               }).FirstOrDefaultAsync();
        }

        public async Task AddActorAsync(AddActorViewModel model)
        {
            var actor = new Actor()
            {
                Bio = model.Bio,
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
            };

            try
            {
                await repo.AddAsync(actor);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(AddActorAsync), ex);
                throw new ApplicationException("Database failed to save");
            }

        }

        public async Task DeleteActorAsync(int actorId)
        {
            var actor = await repo.All<Actor>().FirstOrDefaultAsync(x => x.Id == actorId);
            if (actor != null)
            {
                repo.Delete(actor);
            }

            await repo.SaveChangesAsync();
        }


        public async Task EditActorDetailsAsync(AddActorViewModel model, int actorId)
        {
            var actor =await repo.All<Actor>().Where(x => x.Id == actorId).FirstOrDefaultAsync();
            actor.FullName = model.FullName;
            actor.Bio = model.Bio;
            actor.ImageUrl = model.ImageUrl;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id) => await repo.AllReadonly<Actor>().AnyAsync(x => x.Id == id);

        public async Task<IEnumerable<ActorViewModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Actor>().Select(x => new ActorViewModel
            {
                Id = x.Id,
                Bio = x.Bio,
                FullName = x.FullName,
                ImageUrl = x.ImageUrl,
            }).ToListAsync();
        }

        public Actor GetById(int actorId) => repo.All<Actor>().FirstOrDefault(x => x.Id == actorId);
     

        public Task<ActorViewModel> GetByIdAsync(int actorId)
        {
            return repo.All<Actor>()
                .Where(x => x.Id == actorId)
                .Select(x => new ActorViewModel
            {
                Id = x.Id,
                Bio = x.Bio,
                FullName = x.FullName,
                ImageUrl = x.ImageUrl,
            }).FirstOrDefaultAsync();
        }
    }
}
