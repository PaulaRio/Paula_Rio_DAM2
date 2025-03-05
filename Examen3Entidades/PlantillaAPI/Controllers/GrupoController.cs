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
    public class GrupoController : BaseController<GrupoEntity, GrupoDTO, CreateGrupoDTO>
    {
        public GrupoController(IGrupoRepository grupoRepository, IMapper mapper, ILogger<GrupoController> logger) 
            : base(grupoRepository, mapper, logger)
        {
        }
    }
}
