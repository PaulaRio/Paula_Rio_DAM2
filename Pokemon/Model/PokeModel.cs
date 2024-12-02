using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokemon.Model
{

    public class PokeModel
    {
        public PokeModel()
        {
            Results = new List<Pokes>();
          
        }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("results")]
        public List<Pokes> Results { get; set; }
    }

    public class Pokes
    {
        [JsonPropertyName("name")]
        public string Nombre { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

   

}
