
using ProPokeAPI.Models.DTOs.UserDto;
using AutoMapper;
using ProPokeAPI.Models.Entity;
using ProPokeAPI.Models.DTOs.CategoryDto;

namespace ProPokeAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {


            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
