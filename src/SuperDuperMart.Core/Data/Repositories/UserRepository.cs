using Microsoft.EntityFrameworkCore;
using SuperDuperMart.Core.Entities.Identity;

namespace SuperDuperMart.Core.Data.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly UserManager<User> _userManager;
        private readonly SuperDuperMartDbContext _context;

        public UserRepository(SuperDuperMartDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            var users = await _context.Users
                .Include(u => u.Location)
                .ToListAsync();

            return users;
        }

        public async Task<(int Pages, IEnumerable<User> Data)> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
            {
                return (Pages: 0, Data: Enumerable.Empty<User>());
            }

            int count = await _context.Users.CountAsync();
            decimal pages = Math.Ceiling((decimal)count / pageSize);

            var users = await _context.Users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(u => u.Location)
                .ToListAsync();

            return (Pages: (int)pages, Data: users);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Location)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<bool> HasCartAsync(User user)
        {
            return await _context.Carts.AnyAsync(c => c.UserId == user.Id);
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            var identityResult = await _userManager.CreateAsync(user);
            return identityResult;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }
    }
}
