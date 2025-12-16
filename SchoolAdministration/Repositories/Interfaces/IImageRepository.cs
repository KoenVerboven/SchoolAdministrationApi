using SchoolAdministration.Models.Domain.Student;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<IEnumerable<StudentImage>> GetAllStudentImages();
        Task<StudentImage>Upload(IFormFile file, StudentImage studentImage);
        bool StudentImageExist(string fileName);
    }
}

