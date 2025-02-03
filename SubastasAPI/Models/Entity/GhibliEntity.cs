using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SubastasAPI.Models.Entity
{
    public class GhibliEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int LifetimeGross  { get; set; }

       
    }
}
