using BasicAPI.Models.DTOs.UserDto;
using AutoMapper;
using BasicAPI.Models.DTOs;
using BasicAPI.Models.Entity;
using BasicAPI.Models.DTOs.Ghibli;

namespace BasicAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
           
            CreateMap<GhibliEntity, GhibliDTO>().ReverseMap();
            CreateMap<GhibliEntity, CreateGhibliDTO>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
