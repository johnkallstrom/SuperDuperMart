﻿using Microsoft.EntityFrameworkCore;

namespace SuperDuperMart.Core.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly SuperDuperMartDbContext _context;

        public CartRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public async Task AddItemAsync(CartItem item)
        {
            var existingItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.CartId == item.CartId && ci.ProductId == item.ProductId);
            if (existingItem is null)
            {
                await _context.CartItems.AddAsync(item);
            }
            else
            {
                existingItem.Quantity++;
                _context.CartItems.Update(existingItem);
            }
        }

        public async Task<IEnumerable<CartItem>> GetItemsAsync(Cart cart)
        {
            var cartItems = Enumerable.Empty<CartItem>();

            cartItems = await _context.CartItems
                .Where(ci => ci.CartId == cart.Id)
                .Include(ci => ci.Product)
                .ToListAsync();

            return cartItems;
        }

        public async Task<IEnumerable<Cart>> GetAsync()
        {
            var carts = await _context.Carts.ToListAsync();
            return carts;
        }

        public async Task<Cart?> GetByIdAsync(int id)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.Id == id);
            return cart;
        }

        public async Task<Cart?> GetByUserIdAsync(int userId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            return cart;
        }

        public async Task<Cart> CreateAsync(Cart entity)
        {
            var entry = await _context.Carts.AddAsync(entity);
            return entry.Entity;
        }

        public void Update(Cart entity)
        {
            entity.LastModified = DateTime.Now;
            _context.Carts.Update(entity);
        }

        public void Delete(Cart entity) => _context.Carts.Remove(entity);
    }
}
