using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperDuperMart.Core.Data.Fakers;

namespace SuperDuperMart.Core.Data
{
    public class DatabaseInitializer
    {
        private static readonly string _password = "superduper123";
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
            await CreateAdministrators(userManager, roleManager);
            await CreateCustomers(userManager, roleManager);
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

        private static async Task CreateCustomers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            var customers = _userFaker.Generate(50);
            foreach (var customer in customers)
            {
                customer.PasswordHash = userManager.PasswordHasher.HashPassword(customer, _password);
                var identityResult = await userManager.CreateAsync(customer);
                if (identityResult.Succeeded)
                {
                    var role = await roleManager.FindByNameAsync("Customer");
                    if (role != null && !string.IsNullOrWhiteSpace(role.Name))
                    {
                        await userManager.AddToRoleAsync(customer, role.Name);
                    }
                }
            }
        }

        private static async Task CreateAdministrators(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            var administrators = _userFaker.Generate(10);
            foreach (var admin in administrators)
            {
                admin.PasswordHash = userManager.PasswordHasher.HashPassword(admin, _password);
                var identityResult = await userManager.CreateAsync(admin);
                if (identityResult.Succeeded)
                {
                    var role = await roleManager.FindByNameAsync("Administrator");
                    if (role != null && !string.IsNullOrWhiteSpace(role.Name))
                    {
                        await userManager.AddToRoleAsync(admin, role.Name);
                    }
                }
            }
        }
    }
}
