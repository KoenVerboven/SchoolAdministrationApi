using SchoolAdministration.Models.DTO;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> RoleExistsAsync(string name);
    }
}
