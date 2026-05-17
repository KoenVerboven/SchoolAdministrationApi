using SchoolAdministration.Models.DTO;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        bool RoleExistsAsync(string name);
    }
}
