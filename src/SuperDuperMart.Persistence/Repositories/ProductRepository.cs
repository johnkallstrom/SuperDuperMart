using Microsoft.EntityFrameworkCore;
using SuperDuperMart.Core.Entities;
using SuperDuperMart.Core.Interfaces;
using SuperDuperMart.Persistence.Data;

namespace SuperDuperMart.Persistence.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly SuperDuperMartDbContext _context;

        public ProductRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Get() => _context.Products.AsNoTracking();

        public Product? GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }
    }
}
