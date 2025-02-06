using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SubastasAPI.Models.DTOs.Puja;

namespace SubastasAPI.Models.Entity
{
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        [MaxLength(100, ErrorMessage = "Max char is 100")]
        public string Brand { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(1000, ErrorMessage = "Max char is 1000")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Photo is required")]
        public string Photo { get; set; }

        public ICollection<PujaEntity> Pujas { get; set; }


    }
}
