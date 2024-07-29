namespace SuperDuperMart.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductCreateModel, Product>();
            CreateMap<ProductUpdateModel, Product>();

            // User
            CreateMap<User, UserModel>().ReverseMap();

            // Location
            CreateMap<Location, LocationModel>().ReverseMap();
        }
    }
}
