using PlantillaAPI.Models.DTOs.UserDto;
using AutoMapper;
using PlantillaAPI.Models.DTOs;
using PlantillaAPI.Models.Entity;


namespace PlantillaAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
           
            //CreateMap<GhibliEntity, GhibliDTO>().ReverseMap();
            //CreateMap<GhibliEntity, CreateGhibliDTO>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
