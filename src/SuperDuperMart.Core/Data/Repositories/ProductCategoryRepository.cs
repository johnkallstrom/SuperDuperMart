﻿using Microsoft.EntityFrameworkCore;

namespace SuperDuperMart.Core.Data.Repositories
{
    public class ProductCategoryRepository : IRepository<ProductCategory>
    {
        private readonly SuperDuperMartDbContext _context;

        public ProductCategoryRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetAsync()
        {
            var productCategories = await _context.ProductCategories.ToListAsync();
            return productCategories;
        }

        public Task<PagedList<ProductCategory>> GetAsync(IQueryParams parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            var productCategory = await _context.ProductCategories.FirstOrDefaultAsync(pc => pc.Id == id);
            return productCategory;
        }

        public Task<ProductCategory> CreateAsync(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory?> GetByIdAsync<TProperty>(int id, Expression<Func<ProductCategory, TProperty>> include)
        {
            throw new NotImplementedException();
        }
    }
}
