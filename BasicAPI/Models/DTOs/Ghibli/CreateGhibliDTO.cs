using System.ComponentModel.DataAnnotations;

namespace BasicAPI.Models.DTOs.Ghibli
{
    public class CreateGhibliDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(200, ErrorMessage = "Max char is 200")]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Beneficios is required")]
        public int LifetimeGross { get; set; }

       
    }
}
