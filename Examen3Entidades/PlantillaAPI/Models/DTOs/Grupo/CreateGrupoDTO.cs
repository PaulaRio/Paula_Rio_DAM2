using System.ComponentModel.DataAnnotations;

namespace PlantillaAPI.Models.DTOs.Object
{
    public class CreateGrupoDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Precio is required")]
        public int Precio { get; set; }

        //public List<int> ObjetosIds { get; set; }

        //public string Photo { get; set; }

       
    }
}
