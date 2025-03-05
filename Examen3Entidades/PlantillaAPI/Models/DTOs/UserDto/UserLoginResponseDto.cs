using PlantillaAPI.Models.Entity;

namespace PlantillaAPI.Models.DTOs.UserDto
{
    public class UserLoginResponseDto
    {
        public AppUser User { get; set; }
        public string Token { get; set; }

    }
}
