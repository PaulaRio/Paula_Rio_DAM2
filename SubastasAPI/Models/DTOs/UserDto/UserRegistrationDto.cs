using SubastasAPI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SubastasAPI.Models.DTOs.UserDto
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "Field required: Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field required: Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field required: Password")]
        [PasswordValidation]
        public string Password { get; set; }
        

    }
}
