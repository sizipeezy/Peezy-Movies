namespace PeezyMovies.Core.Models
{
    using PeezyMovies.Infrastructure.Data.Cart;


    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }

        public double Total { get; set; }
    }
}
