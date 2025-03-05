using System.ComponentModel.DataAnnotations;

namespace PlantillaAPI.Models.DTOs.Object
{
    public class CreateAutorDTO
    {

        [Required(ErrorMessage = "IdObjeto is required")]
        public int IdObjeto { get; set; }

        //[Required(ErrorMessage = "IdObjeto is required")]
        //public int IdObjeto { get; set; }

        //public string Photo { get; set; }

        //[Required(ErrorMessage = "Photo is required")]
        //public string Photo { get; set; }
    }
}
