using Microsoft.EntityFrameworkCore;

namespace SuperDuperMart.Core.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly SuperDuperMartDbContext _context;

        public CartRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cart>> GetAsync()
        {
            var carts = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .ToListAsync();

            return carts;
        }

        public async Task<Cart?> GetByIdAsync(int id)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.Id == id);

            return cart;
        }

        public async Task<Cart?> GetByUserIdAsync(int userId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return cart;
        }

        public async Task<Cart> CreateAsync(Cart entity)
        {
            decimal total = 0;
            if (entity.CartItems != null && entity.CartItems.Count() > 0)
            {
                foreach (var item in entity.CartItems)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId);
                    if (product != null)
                    {
                        total += product.Price * item.Quantity;
                    }
                }
            }

            entity.TotalCost = total;

            var entry = await _context.Carts.AddAsync(entity);
            return entry.Entity;
        }

        public void Update(Cart entity)
        {
            if (entity.CartItems != null && entity.CartItems.Count() > 0)
            {
                decimal total = 0;
                var newItems = entity.CartItems.ToList();

                foreach (var item in newItems)
                {
                    var product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId);
                    if (product != null)
                    {
                        total += product.Price * item.Quantity;
                    }
                }

                entity.TotalCost = total;

                var existingItems = _context.CartItems
                    .Where(ci => ci.CartId == entity.Id)
                    .ToList();

                entity.CartItems = newItems
                    .Except(existingItems)
                    .ToList();
            }

            entity.LastModified = DateTime.Now;
            _context.Carts.Update(entity);
        }

        public void Delete(Cart entity) => _context.Carts.Remove(entity);
    }
}
