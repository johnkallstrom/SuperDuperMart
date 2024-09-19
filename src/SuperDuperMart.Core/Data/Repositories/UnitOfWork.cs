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

            CartRepository = new CartRepository(_context);
            ProductRepository = new ProductRepository(_context);
            UserRepository = new UserRepository(_context, _userManager);
        }

        public ICartRepository CartRepository { get; }
        public IRepository<Product> ProductRepository { get; }
        public IUserRepository<User> UserRepository { get; }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
