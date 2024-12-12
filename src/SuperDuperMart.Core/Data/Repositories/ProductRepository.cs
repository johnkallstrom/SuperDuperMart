using Bogus;
using Microsoft.EntityFrameworkCore;

namespace SuperDuperMart.Core.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly Faker _faker = new();
        private readonly SuperDuperMartDbContext _context;

        public ProductRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            return products;
        }

        public async Task<PagedList<Product>> GetAsync(IQueryParams parameters)
        {
            var query = _context.Products.AsQueryable();
            int totalRecords = await _context.Products.CountAsync();

            if (!parameters.PageNumber.HasValue || 
                !parameters.PageSize.HasValue || 
                parameters.PageNumber.Value <= 0)
            {
                var products = await _context.Products
                    .Include(p => p.Category)
                    .ToListAsync();

                return new PagedList<Product>(totalRecords, products);
            }

            decimal totalPages = parameters.PageSize.HasValue ? Math.Ceiling((decimal)totalRecords / parameters.PageSize.Value) : 0;

            switch(parameters.SortBy)
            {
                case nameof(Product.Created):
                    query = parameters.SortOrder == "Desc" ? query.OrderByDescending(p => p.Created) : query.OrderBy(p => p.Created);
                    break;
                case nameof(Product.Name):
                    query = parameters.SortOrder == "Desc" ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name);
                    break;
                case nameof(Product.Price):
                    query = parameters.SortOrder == "Desc" ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price);
                    break;
            }

            query = query
                .Skip((parameters.PageNumber.Value - 1) * parameters.PageSize.Value)
                .Take(parameters.PageSize.Value);

            var data = await query
                .Include(p => p.Category)
                .ToListAsync();

            return new PagedList<Product>(
                parameters.PageNumber.Value,
                parameters.PageSize.Value,
                (int)totalPages,
                totalRecords,
                data);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Image))
            {
                entity.Image = _faker.Image.PlaceholderUrl(width: 640, height: 480);
            }

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
