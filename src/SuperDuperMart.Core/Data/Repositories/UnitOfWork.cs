namespace SuperDuperMart.Core.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SuperDuperMartDbContext _context;

        public UnitOfWork(
            SuperDuperMartDbContext context, 
            UserManager<User> userManager, 
            RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

            RoleRepository = new RoleRepository(_context);
            LocationRepository = new LocationRepository(_context);
            CartRepository = new CartRepository(_context);
            ProductRepository = new ProductRepository(_context);
            UserRepository = new UserRepository(_context, _userManager);
        }

        public IRoleRepository<Role> RoleRepository { get; set; }
        public ILocationRepository LocationRepository { get; set; }
        public ICartRepository CartRepository { get; }
        public IPaginatedRepository<Product> ProductRepository { get; }
        public IUserRepository<User> UserRepository { get; }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
