using SuperDuperMart.Core.Data.Fakers;

namespace SuperDuperMart.Core.Data
{
    public class DatabaseInitializer
    {
        private static readonly string[] _roles = ["Administrator", "Customer"];

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
            var users = _userFaker.Generate(50);

            foreach (var role in _roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new Role { Name = role });
                }
            }
        }
    }
}
