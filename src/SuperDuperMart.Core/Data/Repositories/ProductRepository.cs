using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SuperDuperMart.Core.Data.Repositories
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

        public async Task<Product?> GetByIdAsync<TProperty>(int id, Expression<Func<Product, TProperty>> include)
        {
            var product = await _context.Products.Include(include).FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            var entry = await _context.Products.AddAsync(entity);
            return entry.Entity;
        }

        public void Update(Product entity)
        {
            entity.LastModified = DateTime.Now;
            _context.Products.Update(entity);
        }

        public void Delete(Product entity) => _context.Products.Remove(entity);
    }
}
