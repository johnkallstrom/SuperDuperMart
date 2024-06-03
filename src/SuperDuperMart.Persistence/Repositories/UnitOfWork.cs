using SuperDuperMart.Persistence.DbContexts;

namespace SuperDuperMart.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SuperDuperMartDbContext _context;

        public UnitOfWork(SuperDuperMartDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            ProductRepository = new ProductRepository(_context);
        }

        public IUserRepository UserRepository { get; }
        public IRepository<Product> ProductRepository { get; }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
