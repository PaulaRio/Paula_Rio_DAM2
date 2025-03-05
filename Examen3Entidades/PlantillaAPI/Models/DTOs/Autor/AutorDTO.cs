using System.Text.Json.Serialization;

namespace PlantillaAPI.Models.DTOs.Object
{
    public class AutorDTO : CreateAutorDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }


    }
}
