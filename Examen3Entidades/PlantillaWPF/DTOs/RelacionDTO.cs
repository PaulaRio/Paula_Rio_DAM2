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
        public string IdObjeto { get; set; }

        [JsonPropertyName("idGrupo")]
        public string IdGrupo { get; set; }
    }
}
