using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlantillaAPI.Models.Entity
{
    public class RelacionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IdObjeto { get; set; }
        [Required]
        public int IdGrupo { get; set; }

    }
}
