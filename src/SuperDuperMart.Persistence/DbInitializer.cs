﻿using SuperDuperMart.Persistence.Fakers;

namespace SuperDuperMart.Persistence
{
    public class DbInitializer
    {
        private static ProductFaker _productFaker = new();

        public static async Task SeedAsync(SuperDuperMartDbContext context)
        {
            var products = _productFaker.Generate(100);

            if (products != null && products.Count > 0)
            {
                await context.Products.AddRangeAsync(products);
            }

            await context.SaveChangesAsync();
        }
    }
}
