using Microsoft.EntityFrameworkCore;

namespace SuperDuperMart.Core.Data.Repositories
{
    public class RoleRepository : IRoleRepository<Role>
    {
        private readonly SuperDuperMartDbContext _context;

        public RoleRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAsync() => await _context.Roles.ToListAsync();

        public async Task<Role?> GetByIdAsync(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            return role;
        }
    }
}
