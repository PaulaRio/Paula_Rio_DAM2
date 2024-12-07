using Microsoft.AspNetCore.Mvc;
using MiPokeAPI.DTO;

namespace MiPokeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PokeHistoricoController : ControllerBase
    {
        private readonly ILogger<PokeHistoricoController> _logger;

        public PokeHistoricoController(ILogger<PokeHistoricoController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<HistoricoDTO> Get()
        {
           
        }
    }
}
