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
    public class AutorController : BaseController<AutorEntity, AutorDTO, CreateAutorDTO>
    {
        public AutorController(IAutorRepository autorRepository, IMapper mapper, ILogger<AutorController> logger) 
            : base(autorRepository, mapper, logger)
        {
        }
    }
}
