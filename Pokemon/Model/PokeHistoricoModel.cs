using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokemon.Model
{
    public class PokeHistoricoModel
    {
        [JsonPropertyName("dateStart")]
        public DateTime dateStart { get; set; }
        [JsonPropertyName("dateEnd")]
        public DateTime dateEnd { get; set; }
        [JsonPropertyName("pokeName")]
        public string pokeName { get; set; }
        [JsonPropertyName("damageDoneTrainer")]
        public int damageDoneTrainer { get; set; }
        [JsonPropertyName("damageReceivedTrainer")]
        public int damageReceivedTrainer { get; set; }
        [JsonPropertyName("damageDonePokemon")]
        public int damageDonePokemon { get; set; }

        [JsonPropertyName("@catch")]
        public bool @catch { get; set; }
        [JsonPropertyName("shiny")]
        public bool shiny { get; set; }

    }
}
