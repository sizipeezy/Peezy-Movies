namespace PeezyMovies.Core.Contracts
{
    using PeezyMovies.Core.Models;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IActorService
    {
        Task<bool> Exists(int id);
        Task<IEnumerable<ActorViewModel>> GetAllAsync();

        Task AddActorAsync(AddActorViewModel model);

        Actor GetById(int actorId);

        Task<ActorViewModel> GetByIdAsync(int actorId);

        Task<AddActorViewModel> ActorById(int actorId);

        Task EditActorDetailsAsync(AddActorViewModel model, int actorId);

        Task DeleteActorAsync(int actorId);
    }
}
