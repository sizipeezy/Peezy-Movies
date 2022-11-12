namespace PeezyMovies.Core.Contracts
{
    using PeezyMovies.Infrastructure.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetUserOrder(string userId);

        Task StoreOrder(List<Item> items, string userId, string email);
    }
}
