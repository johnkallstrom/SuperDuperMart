using SuperDuperMart.Core.Data.Fakers;

namespace SuperDuperMart.Core.Data
{
    public class DatabaseInitializer
    {
        private static ProductFaker _productFaker = new();
        private static UserFaker _userFaker = new();

        public static async Task SeedAsync(SuperDuperMartDbContext context)
        {
            var products = _productFaker.Generate(100);
            var users = _userFaker.Generate(50);

            if (products != null && products.Count > 0)
            {
                await context.Products.AddRangeAsync(products);
            }

            if (users != null && users.Count > 0)
            {
                await context.Users.AddRangeAsync(users);
            }

            await context.SaveChangesAsync();
        }
    }
}
