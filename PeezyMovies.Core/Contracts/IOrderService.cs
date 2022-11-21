namespace PeezyMovies.Core.Contracts
{
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetUserOrder(string userId);

        Task StoreOrder(List<Item> items, string userId, string email);
    }
}
