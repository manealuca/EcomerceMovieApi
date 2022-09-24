using MoviesEComerce.Models;

namespace MoviesEComerce.Data.Services
{

        public interface IOrdersService
        {
            public Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
            public Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
        }
    
}
