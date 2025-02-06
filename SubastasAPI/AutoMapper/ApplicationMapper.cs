using SubastasAPI.Models.DTOs.UserDto;
using AutoMapper;
using SubastasAPI.Models.DTOs;
using SubastasAPI.Models.Entity;
using SubastasAPI.Models.DTOs.Products;
using SubastasAPI.Models.DTOs.Puja;


namespace SubastasAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ProductEntity, ProductDTO>().ReverseMap();
            CreateMap<CreateProductDTO,ProductEntity>().ReverseMap();
            CreateMap<PujaEntity, PujaDTO>().ReverseMap();
            CreateMap<CreatePujaDTO,PujaEntity>().ReverseMap();
            
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
