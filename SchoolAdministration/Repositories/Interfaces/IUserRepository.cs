using SchoolAdministration.Models.Domain.General;
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
    }
}
