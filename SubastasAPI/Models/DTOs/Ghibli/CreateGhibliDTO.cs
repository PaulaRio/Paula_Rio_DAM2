using System.ComponentModel.DataAnnotations;

namespace SubastasAPI.Models.DTOs.Ghibli
{
    public class CreateGhibliDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50, ErrorMessage = "Max char is 200")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ReleaseDate is required")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de emisión debe ser una fecha válida")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "LifetimeGross is required")]
        public int LifetimeGross { get; set; }

       
    }
}
