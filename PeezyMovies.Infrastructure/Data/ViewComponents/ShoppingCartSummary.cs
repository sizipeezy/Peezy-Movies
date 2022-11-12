namespace PeezyMovies.Infrastructure.Data.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Infrastructure.Data.Cart;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


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
