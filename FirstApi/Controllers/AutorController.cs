using FirstApi.DTO;
using FirstAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : Controller
    {
        private readonly ILogger<AutorController> _logger;
        
        private static List<AutorDTO> Autores = new List<AutorDTO>()
        {
            new AutorDTO
            {
                Nombre="JKRowling",
                TELF="123456789",
                Libros= new List<int>{1,2,3 }
            },
            new AutorDTO
            {
                Nombre="Jane Austen",
                TELF="987654321",
                Libros= new List<int>{4,5,6 }
            }
        };
        public AutorController(ILogger<AutorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllElement")]
        public IEnumerable<AutorDTO> Get()
        {
            return Autores;
        }
        [HttpGet("{nombre}")]
        public AutorDTO GetOne(string nombre)
        {
            return Autores.FirstOrDefault(x => x.Nombre.Equals(nombre));
        }

        [HttpPost]
        public AutorDTO Post([FromBody] AutorDTO autor)
        {
            if (Autores.Any(x => x.Nombre.Equals( autor.Nombre)))
            {
                return null;
            }
            Autores.Add(autor);
            return autor;
        }

        [HttpPut("{nombre}")]
        public AutorDTO Put([FromBody] AutorDTO autor, string nombre)
        {
            if (!nombre.Equals( autor?.Nombre))
            {
                return null;
            }
            AutorDTO? autorBBDD = Autores.FirstOrDefault(x => x.Nombre.Equals(autor.Nombre));
            if (autorBBDD == null)
            {
                return null;
            }
            autorBBDD.Nombre = autor.Nombre;
            autorBBDD.TELF = autor.TELF;
            autorBBDD.Libros = autor.Libros;
            return autorBBDD;
        }

        [HttpDelete("{nombre}")]
        public bool Remove(string nombre)
        {
            AutorDTO? autorBBDD = Autores.FirstOrDefault(x => x.Nombre.Equals(nombre));
            if (autorBBDD == null)
            {
                return false;
            }
            return Autores.Remove(autorBBDD);
        }
    }
}
