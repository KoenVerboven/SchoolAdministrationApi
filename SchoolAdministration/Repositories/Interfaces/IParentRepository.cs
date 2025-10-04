using SchoolAdministration.Models;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IParentRepository
    {
        Task<IEnumerable<Parent>> GetAllAsync();
        Task<Parent> GetByIdAsync(int id);
        Task<int> CountAsync();
        Task<IEnumerable<Parent>> FindByStudentIdAsync(int studentId);
        Task AddParentAsync(Parent parent);
        Task UpdateParentAsync(Parent parent);
        Task DeleteParentAsync(int id);

    }
}
