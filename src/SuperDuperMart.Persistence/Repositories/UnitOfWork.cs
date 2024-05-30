using SuperDuperMart.Persistence.Data;

namespace SuperDuperMart.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SuperDuperMartDbContext _context;

        public UnitOfWork(SuperDuperMartDbContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
        }

        public IRepository<Product> ProductRepository { get; }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
