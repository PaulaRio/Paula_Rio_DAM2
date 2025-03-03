using PlantillaAPI.Models.DTOs.UserDto;
using AutoMapper;
using PlantillaAPI.Models.DTOs;
using PlantillaAPI.Models.Entity;
using PlantillaAPI.Models.DTOs.Object;


namespace PlantillaAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
           
            CreateMap<ObjectEntity, ObjectDTO>().ReverseMap();
            CreateMap<ObjectEntity, CreateObjectDTO>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
