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
            CreateMap<UserDto, UserUpdateDto>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.Id))
                .ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.Location.StreetName))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Location.ZipCode))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Location.City));
        }
    }
}
