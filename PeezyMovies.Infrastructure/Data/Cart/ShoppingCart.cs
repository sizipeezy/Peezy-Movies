namespace PeezyMovies.Infrastructure.Data.Cart
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PeezyMovies.Infrastructure.Data.Models;

    public class ShoppingCart
    {
        public ShoppingCart(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ApplicationDbContext context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<Item> Items { get; set; }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };
        }

        public List<Item> GetShoppingCartItems() => 
                 Items ??= context.Items
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Include(n => n.Movie)
                .ToList();
        

        public double GetCartTotal() => 
            (double)context.Items
            .Where(n => n.ShoppingCartId == ShoppingCartId)
            .Select(n => n.Movie.Price * n.Quantity)
            .Sum();
        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = context.Items
                .FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new Item()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Quantity = 1
                };

                context.Items.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }

            context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = context.Items
                .FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                }

                context.Items.Remove(shoppingCartItem);

            }
            context.SaveChanges();
        }

        public async Task ClearCart()
        {
            var items = await context.Items
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .ToListAsync();

            context.Items.RemoveRange(items);
            await context.SaveChangesAsync();
        }
    }
}
