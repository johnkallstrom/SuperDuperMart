using Bogus;
using Microsoft.Extensions.Configuration;
using SuperDuperMart.Core.Data.Fakers;

namespace SuperDuperMart.Core.Data
{
    public class DatabaseInitializer
    {
        private static readonly string SECTION = "DatabaseInitilization:Users";
        private static readonly string KEY_ROLES = "Roles";
        private static readonly string KEY_PASSWORD = "Password";

        private static Faker _faker = new();
        private static ProductFaker _productFaker = new();
        private static UserFaker _userFaker = new();

        public static async Task SeedAsync(
            SuperDuperMartDbContext context,
            IConfiguration configuration,
            UserManager<User> userManager, 
            RoleManager<Role> roleManager)
        {
            var products = _productFaker.Generate(100);

            if (products != null && products.Count > 0)
            {
                await context.Products.AddRangeAsync(products);
            }

            await context.SaveChangesAsync();

            await CreateUsers(userManager, roleManager, configuration);
        }

        private static async Task CreateUsers(
            UserManager<User> userManager, 
            RoleManager<Role> roleManager, 
            IConfiguration configuration)
        {
            var section = configuration.GetSection($"{SECTION}:{KEY_ROLES}");
            var roles = section.Get<string[]>();

            string? defaultPassword = configuration.GetValue<string>($"{SECTION}:{KEY_PASSWORD}");

            var users = _userFaker.Generate(100);
            foreach (var user in users)
            {
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, defaultPassword);

                var identityResult = await userManager.CreateAsync(user);
                if (identityResult.Succeeded)
                {
                    string role = _faker.PickRandom(roles);
                    if (!string.IsNullOrEmpty(role))
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            await roleManager.CreateAsync(new Role { Name = role });
                        }

                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }
    }
}
