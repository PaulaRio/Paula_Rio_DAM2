using System.Text.Json.Serialization;

namespace Pokemon.DTO
{
    public class HistoricoDTO
    {
        [JsonPropertyName("startDate")]
        public DateTime? StartDate { get; set; }
        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; set; }
        [JsonPropertyName("pokeName")]
        public string PokeName { get; set; }
        [JsonPropertyName("damageDoneTrainer")]
        public int  DamageDoneTrainer { get; set; }
        [JsonPropertyName("damageReceivedTrainer")]
        public int DamageReceivedTrainer { get; set; }
        [JsonPropertyName("damageDonePokemon")]
        public int DamageDonePokemon { get; set; }
        [JsonPropertyName("catch")]
        public bool Catch { get; set; }



    }
}
