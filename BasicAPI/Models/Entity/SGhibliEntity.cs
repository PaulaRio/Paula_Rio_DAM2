using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BasicAPI.Models.Entity
{
    public class SGhibliEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int Damage { get; set; }

        [Required, MaxLength(50)]
        public string Bastidor { get; set; }
    }
}
