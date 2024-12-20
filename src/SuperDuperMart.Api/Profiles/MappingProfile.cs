﻿using SuperDuperMart.Core.Results;

namespace SuperDuperMart.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

            // ProductCategory
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();

            // User
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            // Role
            CreateMap<Role, RoleDto>().ReverseMap();

            // Location
            CreateMap<Location, LocationDto>().ReverseMap();

            // Cart
            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.CartItems))
                .ReverseMap();

            CreateMap<CartCreateDto, Cart>();
            CreateMap<CartUpdateDto, Cart>();

            // CartItem
            CreateMap<CartItem, CartItemDto>();

            // Results
            CreateMap(typeof(PagedList<>), typeof(PagedListDto<>));
        }
    }
}
