using System.ComponentModel.DataAnnotations;

namespace PlantillaAPI.Models.DTOs.Object
{
    public class CreateObjectDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(300, ErrorMessage = "Max char is 300")]
        public string Email { get; set; }

       
       // public int IdAutor { get; set; }



    }
}
