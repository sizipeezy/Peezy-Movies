namespace PeezyMovies.Infrastructure.Data.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Infrastructure.Data.Cart;


    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart cart;

        public ShoppingCartSummary(ShoppingCart cart)
        {
            this.cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var items = cart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}
