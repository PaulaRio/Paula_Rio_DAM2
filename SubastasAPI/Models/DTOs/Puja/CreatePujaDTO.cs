using System.ComponentModel.DataAnnotations;
using SubastasAPI.Models.DTOs.Products;

namespace SubastasAPI.Models.DTOs.Puja
{
    public class CreatePujaDTO
    {
        [Required(ErrorMessage = "Bid is required")]
        public float Bid { get; set; }

        [Required(ErrorMessage = "IdProduct is required")]
        public int IdProduct { get; set; }
    }
}
