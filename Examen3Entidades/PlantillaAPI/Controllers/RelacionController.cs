using AutoMapper;
using BasicAPI.Controllers.PlantillaAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using PlantillaAPI.Models.DTOs.Relacion;
using PlantillaAPI.Models.Entity;
using PlantillaAPI.Repository;
using PlantillaAPI.Repository.IRepository;

namespace PlantillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelacionController : BaseController<RelacionEntity, RelacionDTO, CreateRelacionDTO>
    {
        public RelacionController(IRelacionRepository relacionRepository, IMapper mapper, ILogger<RelacionController> logger) 
            : base(relacionRepository, mapper, logger)
        {
        }
    }
}
