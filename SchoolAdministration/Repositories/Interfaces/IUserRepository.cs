
using SchoolAdministration.Models.Domain.User;
using SchoolAdministration.Models.DTO;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<UserDTO?> GetByIdAsync(string id);
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<int> CountAsync();
        bool IsInRole(string userId, string roleName);
        Task<bool> AddToRoleAsync(string userId, string roleName);

    }
}
