using Bogus;

namespace SuperDuperMart.Core.Data.Fakers
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Description, f => f.Commerce.ProductDescription());
            RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()));
            RuleFor(p => p.Material, f => f.Commerce.ProductMaterial());
            RuleFor(p => p.Created, DateTime.Now);
        }
    }
}
