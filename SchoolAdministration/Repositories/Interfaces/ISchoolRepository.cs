using SchoolAdministration.Models.Domain;
using SchoolAdministration.Models.Dtos;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<School>> GetAllAsync();
        Task<School?> GetByIdAsync(int id);
        Task AddSchoolAsync(School school);
        Task UpdateSchoolAsync(School school);
        Task DeleteSchoolAsync(int id);
        Task<int> CountAsync();
        bool SchoolExist(SchoolCreateDTO school);
    }
}
