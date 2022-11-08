namespace PeezyMovies.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ActorService : IActorService
    {
        private readonly IRepository repo;

        public ActorService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddActorAsync(AddActorViewModel model)
        {
            var actor = new Actor()
            {
                Bio = model.Bio,
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
            };

            await repo.AddAsync(actor);
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

        public async Task<ActorViewModel> GetActorDetails(int actorId)
        {
            var actor = await repo.All<Actor>().Select(x => new ActorViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Bio = x.Bio,
                ImageUrl = x.ImageUrl,
            }).FirstOrDefaultAsync(x => x.Id == actorId);
            return actor;
        }

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

        public Actor GetById(int actorId)
        {
            return repo.All<Actor>().FirstOrDefault(x => x.Id == actorId);
        }

    
    }
}
