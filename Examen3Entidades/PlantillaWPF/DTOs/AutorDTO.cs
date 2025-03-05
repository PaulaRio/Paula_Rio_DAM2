using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PlantillaWPF.Models;

namespace PlantillaWPF.DTOs
{
    public class AutorDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("idObjeto")]
        public int IdObjeto { get; set; }

        //[JsonPropertyName("photo")]
        //public string Photo { get; set; }

        internal static AutorDTO CreateDTOFromModel(AutorModel objeto)
        {

            return new AutorDTO
            {
                Id = objeto.Id,
                IdObjeto = objeto.IdObjeto,



            };
        }
    }
}
