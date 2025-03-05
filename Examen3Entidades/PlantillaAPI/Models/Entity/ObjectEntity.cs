using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlantillaAPI.Models.Entity
{
    public class ObjectEntity
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(300, ErrorMessage = "Max char is 300")]
        public string Email { get; set; }

        

        


    }
}
