namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data.Cart;


    public class OrdersController : Controller
    {
        private readonly IMovieService movieService;
        private readonly ShoppingCart shoppingCart;

        public OrdersController(
            ShoppingCart shoppingCart,
            IMovieService movieService)
        {
            this.shoppingCart = shoppingCart;
            this.movieService = movieService;
        }

        public IActionResult ShoppingCart()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.Items = items;

            var viewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = shoppingCart,
                Total = shoppingCart.GetCartTotal(),
            };
            return View(viewModel);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int movieId)
        {
            var item = await movieService.GetMovieByIdAsync(movieId);

            if (item != null)
            {
                shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> RemoveItemFromShoppingCart(int movieId)
        {
            var item = await movieService.GetMovieByIdAsync(movieId);

            if (item != null)
            {
                shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
