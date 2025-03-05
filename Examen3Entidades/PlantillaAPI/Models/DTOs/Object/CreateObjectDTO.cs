using System.ComponentModel.DataAnnotations;

namespace PlantillaAPI.Models.DTOs.Object
{
    public class CreateObjectDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(1000, ErrorMessage = "Max char is 1000")]
        public string Description { get; set; }

        public string Photo { get; set; }

        public List<int> AutoresIds { get; set; }

        public List<int> GruposIds { get; set; }

       
    }
}
