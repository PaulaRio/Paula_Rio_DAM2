using AutoMapper;
using BasicAPI.Controllers.BasicAPI.Controllers;
using BasicAPI.Models.DTOs.Ghibli;
using BasicAPI.Models.Entity;
using BasicAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
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
