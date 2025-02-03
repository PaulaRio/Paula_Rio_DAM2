using AutoMapper;
using SubastasAPI.Controllers.SubastasAPI.Controllers;
using SubastasAPI.Models.DTOs.Ghibli;
using SubastasAPI.Models.Entity;
using SubastasAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace SubastasAPI.Controllers
{
    public class GhibliController :BaseController<GhibliEntity,GhibliDTO,CreateGhibliDTO>
    {
        
            public GhibliController(IGhibliRepository GhibliRepository,
                IMapper mapper, ILogger<GhibliController> logger)
                : base(GhibliRepository, mapper, logger)
            {

            }
        
    }
}
