using SchoolAdministration.Models;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<IEnumerable<SchoolClass>> GetAllAsync();
        Task<IEnumerable<SchoolClass>> GetClassesBySchoolIdAsync(int schoolId);
        Task<SchoolClass?> GetByIdAsync(int id);
        Task AddClassAsync(SchoolClass schoolClass);
        Task UpdateClassAsync(SchoolClass schoolClass);
        Task DeleteClassAsync(int id);
        Task<int> CountAsync();
    }
}
