using AutoMapper;

namespace SuperDuperMart.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<Location, LocationResponse>().ReverseMap();
        }
    }
}
