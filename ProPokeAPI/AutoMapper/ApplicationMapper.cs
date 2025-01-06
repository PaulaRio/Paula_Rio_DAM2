
using ProPokeAPI.Models.DTOs.UserDto;
using AutoMapper;
using ProPokeAPI.Models.Entity;

namespace ProPokeAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            
            //CreateMap<EditorialEntity, CreateEditorialDTO>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
