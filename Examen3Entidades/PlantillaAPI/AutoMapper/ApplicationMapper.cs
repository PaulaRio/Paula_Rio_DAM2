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

            CreateMap<AutorEntity, AutorDTO>().ReverseMap();
            CreateMap<AutorEntity, CreateAutorDTO>().ReverseMap();

            CreateMap<GrupoEntity, GrupoDTO>().ReverseMap();
            CreateMap<GrupoEntity, CreateGrupoDTO>().ReverseMap();

            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
