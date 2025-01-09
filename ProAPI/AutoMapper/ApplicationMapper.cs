using ApiPelicula.Models.DTOs.UserDto;
using AutoMapper;

using RestAPI.Models.Entity;

namespace ApiPelicula.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
