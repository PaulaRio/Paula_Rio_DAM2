using System.ComponentModel.DataAnnotations;

namespace PlantillaAPI.Models.DTOs.Object
{
    public class CreateGrupoDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(1000, ErrorMessage = "Max char is 1000")]
        public string Description { get; set; }

        public List<int> ObjetosIds { get; set; }

        //[Required(ErrorMessage = "IdObjeto is required")]
        //public int IdObjeto { get; set; }

        //public List<ObjectDTO> Objetos { get; set; }

        //public string Photo { get; set; }

        //[Required(ErrorMessage = "Photo is required")]
        //public string Photo { get; set; }
    }
}
