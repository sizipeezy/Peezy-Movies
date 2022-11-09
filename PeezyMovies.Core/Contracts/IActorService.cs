namespace PeezyMovies.Core.Contracts
{
    using PeezyMovies.Core.Models;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IActorService
    {
        Task<IEnumerable<ActorViewModel>> GetAllAsync();

        Task AddActorAsync(AddActorViewModel model);

        Actor GetById(int actorId);

        Task<ActorViewModel> GetActorDetails(int actorId);

        Task EditActorDetailsAsync(AddActorViewModel model, int actorId);

        Task DeleteActorAsync(int actorId);
    }
}
