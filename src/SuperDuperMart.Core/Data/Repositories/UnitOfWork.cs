namespace SuperDuperMart.Core.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManager<User> _userManager;
        private readonly SuperDuperMartDbContext _context;

        public UnitOfWork(SuperDuperMartDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            UserRepository = new UserRepository(_context, _userManager);
            ProductRepository = new ProductRepository(_context);
        }

        public IUserRepository UserRepository { get; }
        public IRepository<Product> ProductRepository { get; }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
