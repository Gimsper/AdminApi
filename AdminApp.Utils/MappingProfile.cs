using AdminApp.Core.DTO.Category;
using AdminApp.Core.DTO.Item;
using AdminApp.Core.DTO.Role;
using AdminApp.Core.DTO.User;
using AdminApp.Core.Entities;
using AutoMapper;

namespace AdminApp.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemReadDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<ItemAddDTO, Item>();
            CreateMap<ItemUpdateDTO, Item>();

            CreateMap<Category, CategoryReadDTO>();
            CreateMap<CategoryAddDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();

            CreateMap<User, UserReadDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
            CreateMap<UserAddDTO, User>();
            CreateMap<UserUpdateDTO, User>();

            CreateMap<Role, RoleReadDTO>();
            CreateMap<RoleAddDTO, Role>();
            CreateMap<RoleUpdateDTO, Role>();
        }
    }
}
