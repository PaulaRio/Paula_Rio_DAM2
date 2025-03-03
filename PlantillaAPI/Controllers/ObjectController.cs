using AutoMapper;
using BasicAPI.Controllers.PlantillaAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using PlantillaAPI.Models.DTOs.Object;
using PlantillaAPI.Models.Entity;
using PlantillaAPI.Repository;
using PlantillaAPI.Repository.IRepository;

namespace PlantillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectController : BaseController<ObjectEntity, ObjectDTO, CreateObjectDTO>
    {
        public ObjectController(IObjectRepository objectRepository, IMapper mapper, ILogger<ObjectController> logger) 
            : base(objectRepository, mapper, logger)
        {
        }
    }
}
