namespace SuperDuperMart.Core.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

            // User
            CreateMap<User, UserDto>().ReverseMap();

            // Location
            CreateMap<Location, LocationDto>().ReverseMap();
        }
    }
}
