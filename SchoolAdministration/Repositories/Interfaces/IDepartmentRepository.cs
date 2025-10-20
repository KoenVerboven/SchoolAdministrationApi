using SchoolAdministration.Models.Domain;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<SchoolDepartment>> GetAllAsync();
        Task<IEnumerable<SchoolDepartment>> GetDepartmentBySchoolIdAsync(int schoolId);
        Task<SchoolDepartment?> GetByIdAsync(int id);
        Task AddDepartmentAsync(SchoolDepartment schoolDepartment);
        Task UpdateDepartmentAsync(SchoolDepartment schoolDepartment);
        Task DeleteDepartmentAsync(int id);
        Task<int> CountAsync();
    }
}
