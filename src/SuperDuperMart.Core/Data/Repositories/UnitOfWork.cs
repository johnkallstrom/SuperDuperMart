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

            LocationRepository = new LocationRepository(_context);
            CartRepository = new CartRepository(_context);
            ProductRepository = new ProductRepository(_context);
            UserRepository = new UserRepository(_context, _userManager);
        }

        public ILocationRepository LocationRepository { get; set; }
        public ICartRepository CartRepository { get; }
        public IPaginatedRepository<Product> ProductRepository { get; }
        public IUserRepository<User> UserRepository { get; }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
