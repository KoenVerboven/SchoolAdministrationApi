using SchoolAdministration.Models.DTO;
using SchoolAdministration.Models.Domain.Student;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IStudentPresenceRepository
    {
        Task<IEnumerable<StudentPresence>> GetAllAsync();
        Task<StudentPresence?> GetByIdAsync(int id);
        Task AddStudentPresenceAsync(StudentPresence student);
        Task AddStudentsPresenceAsync(IEnumerable<StudentPresence> studentsPresence);
        Task UpdateStudentPresenceAsync(StudentPresence student);
        Task DeleteStudentPresenceAsync(int id);
    }
}
