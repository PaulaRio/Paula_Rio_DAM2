using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlantillaAPI.Models.Entity
{
    public class AutorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
       public int IdObjeto { get; set; }

        //public string Photo { get; set; }
        //public ObjectEntity()
        //{
        //    CreatedDate = DateTime.UtcNow;
        //}
        public AutorEntity()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
