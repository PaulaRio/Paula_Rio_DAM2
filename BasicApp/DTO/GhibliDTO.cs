using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BasicApp.DTO
{
    public class GhibliDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Titulo { get; set; }
        [JsonPropertyName("releaseDate")]
        public String Estreno { get; set; }
        [JsonPropertyName("lifetimeGross")]
        public int Taquilla { get; set; }
        

    }
}
