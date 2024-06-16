using Microsoft.EntityFrameworkCore;
using SuperDuperMart.Persistence.DbContexts;

namespace SuperDuperMart.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SuperDuperMartDbContext _context;

        public UserRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            var users = await _context.Users
                .Include(u => u.Location)
                .ToListAsync();

            return users;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Location)
                .FirstOrDefaultAsync(c => c.Id == id);

            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Email == email);
            return user;
        }

        public bool CheckPassword(User user, string password) => user.Password == password;
    }
}
