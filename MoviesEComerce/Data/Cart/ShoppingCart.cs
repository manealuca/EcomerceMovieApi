using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Models;
using Microsoft.Extensions.DependencyInjection;


namespace MoviesEComerce.Data.Cart
{
    public class ShoppingCart
    {
        public MovieComerceContext _context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(MovieComerceContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<MovieComerceContext>();

            string cartId = session.GetString("CartId")?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };

        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.shoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem is null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                _context.shoppingCartItems.Add(shoppingCartItem);
                var a = _context.shoppingCartItems.ToList();

            }else
            {
                shoppingCartItem.Amount+=1;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.shoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if(!(shoppingCartItem is null))
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount --;
                }
                else
                {
                    _context.shoppingCartItems.Remove(shoppingCartItem);
                }
                
            }
            _context.SaveChanges();
        }

        public  List<ShoppingCartItem> GetShoppingCartItems()
        {
            //List<ShoppingCartItem> shopppingCarItems =  _context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(m => m.Movie).ToList();
             return ShoppingCartItems ?? (ShoppingCartItems = _context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
            //return shopppingCarItems;
        }
        public  double GetShoppingCartTotal()
        {
            double total = _context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n=>n.Movie.Price*n.Amount).Sum();
            return total;
        }

        public async Task ClearShoppingCart()
        {
            var items = _context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.RemoveRange(items);
            _context.SaveChanges();
        }

    }
}
