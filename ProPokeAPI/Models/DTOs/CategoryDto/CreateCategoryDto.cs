using System.ComponentModel.DataAnnotations;

namespace ProPokeAPI.Models.DTOs.CategoryDto
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Max char is 100")]
        public string Name { get; set; }

    }
}
