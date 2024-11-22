using Microsoft.EntityFrameworkCore;
using SuperDuperMart.Core.Entities;

namespace SuperDuperMart.Core.Data.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SuperDuperMartDbContext _context;

        public UserRepository(
            SuperDuperMartDbContext context, 
            UserManager<User> userManager, 
            RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            var users = await _context.Users
                .Include(u => u.Location)
                .ToListAsync();

            return users;
        }

        public async Task<PagedList<User>> GetAsync(IQueryParams parameters)
        {
            var users = Enumerable.Empty<User>();
            var totalRecords = await _context.Users.CountAsync();

            if (!parameters.PageNumber.HasValue ||
                !parameters.PageSize.HasValue ||
                parameters.PageNumber.Value <= 0)
            {
                users = await _context.Users.ToListAsync();
                return new PagedList<User>(totalRecords, users);
            }

            decimal totalPages = parameters.PageSize.HasValue ? Math.Ceiling((decimal)totalRecords / parameters.PageSize.Value) : 0;

            users = await _context.Users
                .Skip((parameters.PageNumber.Value - 1) * parameters.PageSize.Value)
                .Take(parameters.PageSize.Value)
                .ToListAsync();

            return new PagedList<User>(
                parameters.PageNumber.Value,
                parameters.PageSize.Value,
                (int)totalPages,
                totalRecords,
                users);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Location)
                .Include(u => u.Cart)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<bool> HasCartAsync(User user)
        {
            return await _context.Carts.AnyAsync(c => c.UserId == user.Id);
        }

        public async Task<(bool Succeeded, IEnumerable<string> Errors)> CreateAsync(User user, string password)
        {
            user.Created = DateTime.Now;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);

            var identityResult = await _userManager.CreateAsync(user);
            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(x => x.Description).ToList();
                return (false, errors);
            }

            return (true, Enumerable.Empty<string>());
        }

        public async Task<(bool Succeeded, IEnumerable<string> Errors)> UpdateAsync(User user)
        {
            user.LastModified = DateTime.Now;

            var identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(x => x.Description).ToList();
                return (false, errors);
            }

            return (true, Enumerable.Empty<string>());
        }

        public async Task<(bool Succeeded, IEnumerable<string> Errors)> DeleteAsync(User user)
        {
            var identityResult = await _userManager.DeleteAsync(user);
            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(x => x.Description).ToList();
                return (false, errors);
            }

            return (true, Enumerable.Empty<string>());
        }

        public async Task<Role?> GetPrimaryRoleAsync(User user)
        {
            var roles = await GetRolesAsync(user);
            return roles.FirstOrDefault();
        }

        public async Task<IEnumerable<Role>> GetRolesAsync(User user)
        {
            var listOfRoleNames = await _userManager.GetRolesAsync(user);

            var roles = new List<Role>();
            foreach (var roleName in listOfRoleNames)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role is not null)
                {
                    roles.Add(role);
                }
            }

            return roles;
        }

        public async Task<(bool Succeeded, IEnumerable<string> Errors)> ClearRolesAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var identityResult = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(x => x.Description).ToList();
                return (false, errors);
            }

            return (true, Enumerable.Empty<string>());
        }

        public async Task AddToRoleAsync(User user, string role)
        {
            if (!string.IsNullOrEmpty(role) && await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
