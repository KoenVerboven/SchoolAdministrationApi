using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Models.DTO;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<IEnumerable<StudentExamsResultDTO>> GetStudentExamResultsAsync();
        Task<IEnumerable<StudentCourseDTO>> GetStudentCoursesAsync(int studentId);
        Task<IEnumerable<Student>> GetByNameStartWithAsync(string name);

        //Task<IEnumerable<Student>> GetFilterAsync1(StudentSpecParams studentSpecParams);
        Task<IEnumerable<Student>> GetFilterAsync(string? Name, string? Email, int ZipCode, string Sort, int PageSize, int PageNumber);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        bool StudentExist(Student student);
        Task <int>CountAsync();
        Task<int> CountFilterAsync(string? Name, string? Email, int ZipCode);
    }
}
