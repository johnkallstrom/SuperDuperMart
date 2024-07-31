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
                .Include(c => c.User)
                .ToListAsync();

            return carts;
        }

        public async Task<Cart?> GetByIdAsync(int id)
        {
            var cart = await _context.Carts
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);

            return cart;
        }

        public async Task<Cart?> GetByUserIdAsync(int userId)
        {
            var cart = await _context.Carts
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.UserId == userId);

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
