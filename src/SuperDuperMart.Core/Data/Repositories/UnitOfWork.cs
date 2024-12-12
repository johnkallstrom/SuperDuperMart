namespace SuperDuperMart.Core.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SuperDuperMartDbContext _context;

        public UnitOfWork(
            SuperDuperMartDbContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            SignInManager<User> signInManager,
            IJwtProvider jwtProvider)
        {
            _context = context;
            _jwtProvider = jwtProvider;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;

            RoleRepository = new RoleRepository(_context);
            LocationRepository = new LocationRepository(_context);
            CartRepository = new CartRepository(_context);
            ProductCategoryRepository = new ProductCategoryRepository(_context);
            ProductRepository = new ProductRepository(_context);
            UserRepository = new UserRepository(_context, _userManager, _roleManager, _signInManager, _jwtProvider);
        }

        public IRoleRepository<Role> RoleRepository { get; }
        public ILocationRepository LocationRepository { get; }
        public ICartRepository CartRepository { get; }
        public IRepository<ProductCategory> ProductCategoryRepository { get; }
        public IRepository<Product> ProductRepository { get; }
        public IUserRepository<User> UserRepository { get; }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
