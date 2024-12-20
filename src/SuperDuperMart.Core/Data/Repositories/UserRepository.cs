﻿using Bogus;
using Microsoft.EntityFrameworkCore;

namespace SuperDuperMart.Core.Data.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly Faker _faker = new();
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SuperDuperMartDbContext _context;

        public UserRepository(
            SuperDuperMartDbContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            SignInManager<User> signInManager,
            IJwtProvider jwtProvider)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtProvider = jwtProvider;
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
            var query = _context.Users.AsQueryable();
            int totalRecords = await _context.Users.CountAsync();

            if (!parameters.PageNumber.HasValue ||
                !parameters.PageSize.HasValue ||
                parameters.PageNumber.Value <= 0)
            {
                var users = await _context.Users
                    .Include(u => u.Location)
                    .ToListAsync();

                return new PagedList<User>(totalRecords, users);
            }

            decimal totalPages = parameters.PageSize.HasValue ? Math.Ceiling((decimal)totalRecords / parameters.PageSize.Value) : 0;

            switch(parameters.SortBy)
            {
                case nameof(User.Created):
                    query = parameters.SortOrder == "Desc" ? query.OrderByDescending(u => u.Created) : query.OrderBy(u => u.Created);
                    break;
                case nameof(User.LastModified):
                    query = parameters.SortOrder == "Desc" ? query.OrderByDescending(u => u.LastModified) : query.OrderBy(u => u.LastModified);
                    break;
                case nameof(User.UserName):
                    query = parameters.SortOrder == "Desc" ? query.OrderByDescending(u => u.UserName) : query.OrderBy(u => u.UserName);
                    break;
            }

            query = query
                .Skip((parameters.PageNumber.Value - 1) * parameters.PageSize.Value)
                .Take(parameters.PageSize.Value);

            var pagedUsers = await query
                .Include(u => u.Location)
                .ToListAsync();

            return new PagedList<User>(
                parameters.PageNumber.Value,
                parameters.PageSize.Value,
                (int)totalPages,
                totalRecords,
                pagedUsers);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Location)
                .Include(u => u.Cart)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<string?> AuthenticateAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);
                if (signInResult.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    string token = _jwtProvider.GenerateToken(user, roles.ToArray());

                    return token;
                }
            }

            return default;
        }

        public async Task<bool> HasCartAsync(User user)
        {
            return await _context.Carts.AnyAsync(c => c.UserId == user.Id);
        }

        public async Task<(bool Succeeded, int UserId, IEnumerable<string> Errors)> CreateAsync(User user, string password)
        {
            user.Avatar = _faker.Image.PlaceholderUrl(width: 640, height: 480);
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            user.Created = DateTime.Now;

            var identityResult = await _userManager.CreateAsync(user);
            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(x => x.Description).ToList();
                return (false, default, errors);
            }

            return (true, user.Id, Enumerable.Empty<string>());
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
