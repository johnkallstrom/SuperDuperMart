namespace SuperDuperMart.Web.Features.Products
{
    public partial class Index
    {
        public IEnumerable<ProductModel> Model { get; set; } = default!;

        protected override void OnInitialized()
        {
            Model = new List<ProductModel>
            {
                new ProductModel
                {
                    Id = 1,
                    Name = "Practical Metal Sausages",
                    Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                    Price = 715.84m,
                    Material = "Rubber"
                }
            };
        }
    }
}
