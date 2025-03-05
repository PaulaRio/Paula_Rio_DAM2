using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlantillaWPF.DTOs
{
    public class RelacionDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("idObjeto")]
        public int IdObjeto { get; set; }

        [JsonPropertyName("idGrupo")]
        public int IdGrupo { get; set; }
    }
}
