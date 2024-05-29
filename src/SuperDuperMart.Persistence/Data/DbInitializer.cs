using SuperDuperMart.Persistence.Fakers;

namespace SuperDuperMart.Persistence.Data
{
    public class DbInitializer
    {
        private static ProductFaker _productFaker = new();
        private static CustomerFaker _customerFaker = new();

        public static async Task SeedAsync(SuperDuperMartDbContext context)
        {
            var products = _productFaker.Generate(100);
            var customers = _customerFaker.Generate(50);

            if (products != null && products.Count > 0)
            {
                await context.Products.AddRangeAsync(products);
            }

            if (customers != null && customers.Count > 0)
            {
                await context.Customers.AddRangeAsync(customers);
            }

            await context.SaveChangesAsync();
        }
    }
}
