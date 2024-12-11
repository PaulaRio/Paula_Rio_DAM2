using ExamenAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ExamenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GalaxyController : Controller
    {
        private readonly ILogger<PlanetDTO> _logger;

        private static List<PlanetDTO> Planetas = new List<PlanetDTO>()
        {
            new PlanetDTO
            {
               Nombre="Kepler-22b",
               DistanciaTierra=620,
               Tipo="Terrestrial",
               Atmosfera="Oxygen,Carbon Dioxide",
               Temperatura=22,
               NombreImagen="Planet_1"


            },
        };

        public GalaxyController(ILogger<PlanetDTO> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllElement")]
        public IEnumerable<PlanetDTO> Get()
        {
            return Planetas;
        }

        

        [HttpPost]
        public List<PlanetDTO>  Post([FromBody] PlanetDTO planeta)
        {
            Planetas.Add(planeta);
            return Planetas;
        }

   
        [HttpDelete]
        public bool Remove()
        {
            if(Planetas.Count == 0)
            {
                return false;
            }
            Planetas.Clear();
            return true;
        }
    }


}
