using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlantillaAPI.Models.Entity
{
    public class GrupoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Precio is required")]
        public int Precio { get; set; }

        //public List<int> ObjetosIds { get; set; }

        //public string Photo { get; set; }
        //public ObjectEntity()
        //{
        //    CreatedDate = DateTime.UtcNow;
        //}
    }
}
