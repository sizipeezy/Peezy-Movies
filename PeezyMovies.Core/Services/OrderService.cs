namespace PeezyMovies.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Exceptions;
    using PeezyMovies.Infrastructure.Data.Common;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrderService : IOrderService
    {
        private readonly IRepository repo;
        private readonly IGuard guard;

        public OrderService(IRepository repo, IGuard guard)
        {
            this.repo = repo;
            this.guard = guard;
        }

        public async Task<IEnumerable<Order>> GetUserOrder(string userId)
        {
            var orders = await repo.All<Order>()
                .Include(x => x.OrderItems)
                .ThenInclude(c => c.Movie)
            .Where(x => x.UserId == userId)
            .ToListAsync();

            guard.AgainstNull(orders, "Orders cannot be found");

            return orders;
        }

        public async Task StoreOrder(List<Item> items, string userId, string email)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = email,
            };

            await repo.AddAsync(order);
            await repo.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Quantity,
                    Price = item.Movie.Price,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                };

                await repo.AddAsync(orderItem);
            }

            await repo.SaveChangesAsync();
        }
    }
}
