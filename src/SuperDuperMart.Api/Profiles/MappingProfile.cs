using AutoMapper;

namespace SuperDuperMart.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<ProductCreateRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>();

            // User
            CreateMap<User, UserResponse>().ReverseMap();

            // Location
            CreateMap<Location, LocationResponse>().ReverseMap();
        }
    }
}
