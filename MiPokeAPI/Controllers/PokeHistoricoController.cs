using Microsoft.AspNetCore.Mvc;
using MiPokeAPI.DTO;

namespace MiPokeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PokeHistoricoController : ControllerBase
    {
        private static List<HistoricoDTO> Pokemons = new List<HistoricoDTO>();
        private readonly ILogger<PokeHistoricoController> _logger;

        public PokeHistoricoController(ILogger<PokeHistoricoController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<HistoricoDTO> Get()
        {
           return Pokemons;
        }
        [HttpGet]
        public IEnumerable<HistoricoDTO> GetCatched()
        {
            List<HistoricoDTO> capturedPokemons = new List<HistoricoDTO>();
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Catch) capturedPokemons.Add(pokemon);
            }
            return capturedPokemons;
           
        }
    }
}
