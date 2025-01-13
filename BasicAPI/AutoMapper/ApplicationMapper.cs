using BasicAPI.Models.DTOs.UserDto;
using AutoMapper;
using BasicAPI.Models.DTOs;
using BasicAPI.Models.Entity;

namespace BasicAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
           
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
