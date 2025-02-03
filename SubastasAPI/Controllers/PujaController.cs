using AutoMapper;
using SubastasAPI.Controllers.SubastasAPI.Controllers;
using SubastasAPI.Models.DTOs.Puja;
using SubastasAPI.Models.Entity;
using SubastasAPI.Repository;
using SubastasAPI.Repository.IRepository;

namespace SubastasAPI.Controllers
{
    public class PujaController : BaseController<PujaEntity,PujaDTO,CreatePujaDTO>
    {
        public PujaController(IPujaRepository PujaRepository,
            IMapper mapper, ILogger<PujaController> logger)
            : base(PujaRepository, mapper, logger)
        {
        }
    }
}
