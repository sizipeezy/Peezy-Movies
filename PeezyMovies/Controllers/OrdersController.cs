namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data.Cart;

    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IMovieService movieService;
        private readonly ShoppingCart shoppingCart;
        private readonly IOrderService orderService;

        public OrdersController(
            ShoppingCart shoppingCart,
            IMovieService movieService,
            IOrderService orderService)
        {
            this.shoppingCart = shoppingCart;
            this.movieService = movieService;
            this.orderService = orderService;
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

        public async Task<IActionResult> ProceedOrder()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.Items = items;

            var viewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = shoppingCart,
                Total = shoppingCart.GetCartTotal(),
            };

           await shoppingCart.ClearCart();
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
