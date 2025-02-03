using SubastasAPI.Models.DTOs.UserDto;
using AutoMapper;

using SubastasAPI.Models.Entity;

namespace SubastasAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
