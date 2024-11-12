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
    }
}
