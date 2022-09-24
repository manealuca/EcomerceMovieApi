﻿using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Models;
using System;

namespace MoviesEComerce.Data.Services
{
    public class OrderService : IOrdersService
    {
        private readonly MovieComerceContext _context;
        public OrderService(MovieComerceContext context)
        {
            _context = context;
        }


        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Include(n => n.User).ToListAsync();
            if (userRole != "Admin") orders = orders.Where(n => n.UserId == userId).ToList();
            
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Ammount = item.Amount,
                    MovieId = item.Movie.Id,
                    Id = item.Id,
                    Price = item.Movie.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
           await _context.SaveChangesAsync();
        }
    }
}
