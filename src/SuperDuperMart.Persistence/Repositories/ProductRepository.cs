using Microsoft.EntityFrameworkCore;
using SuperDuperMart.Persistence.DbContexts;

namespace SuperDuperMart.Persistence.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly SuperDuperMartDbContext _context;

        public ProductRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            var entry = await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
