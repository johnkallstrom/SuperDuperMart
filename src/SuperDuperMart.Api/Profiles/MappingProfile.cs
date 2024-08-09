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
            CreateMap<Cart, CartModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.CartItems))
                .ReverseMap();

            CreateMap<CartCreateModel, Cart>()
                .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.Items));

            CreateMap<CartUpdateModel, Cart>();

            // CartItem
            CreateMap<CartItem, CartItemModel>();
            CreateMap<CartItemAddModel, CartItem>();
        }
    }
}
