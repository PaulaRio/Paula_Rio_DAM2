using SubastasAPI.Models.DTOs.UserDto;
using AutoMapper;
using SubastasAPI.Models.DTOs;
using SubastasAPI.Models.Entity;
using SubastasAPI.Models.DTOs.Ghibli;

namespace SubastasAPI.AutoMapper
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
