using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SubastasAPI.Models.Entity
{//TODO en Angular poner que si la puja es 0.0 modificarla y asociarla a un producto
    public class PujaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public float Bid { get; set; }

        [Required]
        public int IdProduct { get; set; }




    }
}
