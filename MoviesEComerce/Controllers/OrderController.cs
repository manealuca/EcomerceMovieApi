using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesEComerce.Data.Cart;
using MoviesEComerce.Data.Services;
using MoviesEComerce.Models;
using System.Security.Claims;

namespace MoviesEComerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBaseRepository<Movie> _movieService;
        private readonly IOrdersService _orderService;
        private readonly ShoppingCart _shoppingCart;

        
        public OrderController(IBaseRepository<Movie> movieService, IOrdersService orderService,ShoppingCart shoppingCart)
        {
            _movieService = movieService;
            _orderService = orderService;
            _shoppingCart = shoppingCart;
        }
        public async Task<IActionResult> Index()
        {
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _orderService.GetOrdersByUserIdAndRoleAsync(UserId, userRole);
         
            return View(orders);
        }

        public IActionResult ShoppingCart(int id)
        {
            
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                
            };

            return View(response);
        }
       
        public async Task<IActionResult> AddItemToShopCart(int id)
        {
            var item =  await _movieService.GetByIdAsync(id);
            if (!(item is null))
            {
                _shoppingCart.AddItemToCart(item);
                
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveToShopCart(int id)
        {
            var item = await _movieService.GetByIdAsync(id);
            if (!(item is null))
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task <IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _orderService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCart();
            return View("OrderCompleted");
        }
    }
}
