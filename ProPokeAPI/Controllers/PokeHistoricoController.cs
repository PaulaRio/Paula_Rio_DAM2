using Microsoft.AspNetCore.Mvc;
using ProPokeAPI.Models.DTOs.HistoricoDto;

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
        private static List<HistoricoDTO> Pokemon = new List<HistoricoDTO>()
{
    new HistoricoDTO
    {

        DateStart = new DateTime(2024, 12, 25, 14, 30, 0), // Año, Mes, Día, Hora, Minuto, Segundo
        DateEnd = new DateTime(2024, 12, 25, 18, 45, 0),  // Otra fecha y hora específica
        PokeName = "pikachu",
        DamageDoneTrainer = 0,
        DamageReceivedTrainer = 0,
        DamageDonePokemon = 0,
        Catch = true,
        Shiny = false
    },
    new HistoricoDTO
    {

        DateStart = new DateTime(2024, 12, 26, 14, 30, 0),
        DateEnd = new DateTime(2024, 12, 26, 18, 45, 0),
        PokeName = "pikachu",
        DamageDoneTrainer = 0,
        DamageReceivedTrainer = 0,
        DamageDonePokemon = 0,
        Catch = true,
        Shiny = false
    },
    new HistoricoDTO
    {

        DateStart = new DateTime(2024, 12, 27, 22, 30, 0),
        DateEnd = new DateTime(2024, 12, 27, 23, 45, 0),
        PokeName = "charmander",
        DamageDoneTrainer = 52,
        DamageReceivedTrainer = 13,
        DamageDonePokemon = 41,      
        Catch = true,
        Shiny = false
    },
    new HistoricoDTO
    {

        DateStart = new DateTime(2024, 12, 30, 23, 30, 0),
        DateEnd = new DateTime(2024, 12, 31, 2, 45, 0),
        PokeName = "charmander",
        DamageDoneTrainer = 78,
        DamageReceivedTrainer = 102,
        DamageDonePokemon = 99,
        Catch = true,
        Shiny = true
    },
};

        [HttpGet]
        public IEnumerable<HistoricoDTO> Get()
        {
           return Pokemons;
        }
        [HttpGet("catched")]
        public IEnumerable<HistoricoDTO> GetCatched()
        {
            List<HistoricoDTO> capturedPokemons = new List<HistoricoDTO>();
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Catch) capturedPokemons.Add(pokemon);
            }
            return capturedPokemons;
           
        }
        [HttpPost]
        public List<HistoricoDTO> Post([FromBody] HistoricoDTO pokemon)
        {
            Pokemons.Add(pokemon);
            return Pokemons;
        }

        [HttpDelete]
        public bool DeleteAll()
        {
            if(Pokemons.Count==0)
            {
                return false;
            }
            Pokemons.Clear();
            return true;
        }

        


    }
}
