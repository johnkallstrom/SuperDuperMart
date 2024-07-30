using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperDuperMart.Core.Data.Fakers;

namespace SuperDuperMart.Core.Data
{
    public class DatabaseInitializer
    {
        private static readonly string[] _roles = ["Administrator", "Customer"];

        private static Faker _faker = new();
        private static ProductFaker _productFaker = new();
        private static UserFaker _userFaker = new();

        public static async Task SeedAsync(SuperDuperMartDbContext context)
        {
            var products = _productFaker.Generate(100);

            if (products != null && products.Count > 0)
            {
                await context.Products.AddRangeAsync(products);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedIdentityAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            await CreateRoles(roleManager);
            await CreateUsers(userManager, roleManager);
        }

        private static async Task CreateRoles(RoleManager<Role> roleManager)
        {
            foreach (var role in _roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new Role { Name = role });
                }
            }
        }

        private static async Task CreateUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            var users = _userFaker.Generate(50);
            foreach (var user in users)
            {
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, _faker.Internet.Password());
                var identityResult = await userManager.CreateAsync(user);
                if (identityResult.Succeeded)
                {
                    var roles = await roleManager.Roles.ToListAsync();
                    foreach (var role in roles)
                    {
                        if (role != null && !string.IsNullOrWhiteSpace(role.Name))
                        {
                            await userManager.AddToRoleAsync(user, role.Name);
                        }
                    }
                }
            }
        }
    }
}
