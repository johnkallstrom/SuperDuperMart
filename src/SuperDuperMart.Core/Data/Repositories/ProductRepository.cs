using Microsoft.EntityFrameworkCore;

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

        public async Task<Result<Product>> GetAsync(IQueryParams parameters)
        {
            var products = Enumerable.Empty<Product>();
            int totalRecords = await _context.Products.CountAsync();

            if (!parameters.PageNumber.HasValue || 
                !parameters.PageSize.HasValue || 
                parameters.PageNumber.Value <= 0)
            {
                products = await _context.Products.ToListAsync();
                return new Result<Product>(totalRecords, products);
            }

            decimal totalPages = parameters.PageSize.HasValue ? Math.Ceiling((decimal)totalRecords / parameters.PageSize.Value) : 0;

            products = await _context.Products
                .Skip((parameters.PageNumber.Value - 1) * parameters.PageSize.Value)
                .Take(parameters.PageSize.Value)
                .ToListAsync();

            return new Result<Product>(
                parameters.PageNumber.Value, 
                parameters.PageSize.Value, 
                (int)totalPages, 
                totalRecords, 
                products);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
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
