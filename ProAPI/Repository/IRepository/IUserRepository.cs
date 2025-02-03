using SubastasAPI.Models.DTOs.UserDto;
using SubastasAPI.Models.Entity;

namespace SubastasAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        ICollection<AppUser> GetUsers();
        AppUser GetUser(string id);
        bool IsUniqueUser(string userName);
        Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto);
        Task<UserLoginResponseDto> Register(UserRegistrationDto userRegistrationDto);
    }
}
