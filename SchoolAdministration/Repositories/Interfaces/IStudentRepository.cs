using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Specifications;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<IEnumerable<StudentExamsResultDTO>> GetStudentExamResultsAsync();
        Task<IEnumerable<StudentAddressDTO>> GetStudentAddressesAsync(int studentId);
        Task<IEnumerable<StudentCourseDTO>> GetStudentCoursesAsync(int studentId);
        Task<IEnumerable<Student>> GetByNameStartWithAsync(string name);
        //obsolete:
        Task<IEnumerable<Student>> GetStudentsByFilterAsyncOld(string? Name, string? Email, int ZipCode, string Sort, int PageSize, int PageNumber);
        Task<IEnumerable<Student>> GetStudentsByFilterAsync(StudentSearchParams studentSearchParams);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        bool StudentExist(Student student);
        Task <int>CountAsync();
        Task<int> CountStudentsByFilterAsync(string? Name, string? Email, int ZipCode);
    }
}
