using SuperDuperMart.Shared.Models.Carts;

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

            // Cart
            CreateMap<Cart, CartModel>().ReverseMap();
            CreateMap<CartCreateModel, Cart>();
        }
    }
}
