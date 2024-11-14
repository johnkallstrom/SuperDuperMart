using Bogus;
using SuperDuperMart.Core.Data.Fakers;

namespace SuperDuperMart.Core.Data
{
    public class DatabaseInitializer
    {
        private static readonly string[] _roles = ["Customer", "Administrator"];
        private static readonly string _password = "superduper123";

        private static Faker _faker = new();
        private static ProductFaker _productFaker = new();
        private static UserFaker _userFaker = new();

        public static async Task SeedAsync(
            SuperDuperMartDbContext context, 
            UserManager<User> userManager, 
            RoleManager<Role> roleManager)
        {
            var products = _productFaker.Generate(100);

            if (products != null && products.Count > 0)
            {
                await context.Products.AddRangeAsync(products);
            }

            await context.SaveChangesAsync();

            await CreateUsers(userManager, roleManager);
        }

        private static async Task CreateUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            var users = _userFaker.Generate(100);
            foreach (var user in users)
            {
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, _password);

                var identityResult = await userManager.CreateAsync(user);
                if (identityResult.Succeeded)
                {
                    string role = _faker.PickRandom(_roles);
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
