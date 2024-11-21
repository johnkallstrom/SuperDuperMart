using AutoMapper;

namespace SuperDuperMart.Web.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<ProductDto, ProductUpdateDto>();

            // User
            CreateMap<UserDto, UserUpdateDto>();
        }
    }
}
