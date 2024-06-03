using Microsoft.EntityFrameworkCore;
using SuperDuperMart.Persistence.DbContexts;

namespace SuperDuperMart.Persistence.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly SuperDuperMartDbContext _context;

        public UserRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            var customers = await _context.Users.ToListAsync();
            return customers;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var customer = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var customer = await _context.Users.FirstOrDefaultAsync(c => c.Email == email);
            return customer;
        }
    }
}
