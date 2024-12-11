using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Examen.DTO
{
    public class EjemploDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }
        [JsonPropertyName("isbn")]
        public string ISBN { get; set; }
        [JsonPropertyName("numPaginas")]
        public int NumPaginas { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string PokeName { get; set; }
        public int DamageDoneTrainer { get; set; }
        public int DamageReceivedTrainer { get; set; }
        public int DamageDonePokemon { get; set; }
        public bool Catch { get; set; }
        public bool Shiny { get; set; }

    }
}
