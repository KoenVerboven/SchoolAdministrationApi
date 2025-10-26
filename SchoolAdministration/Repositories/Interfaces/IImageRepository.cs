using SchoolAdministration.Models.Domain;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<IEnumerable<StudentImage>> GetAllStudentImages();
        Task<StudentImage>Upload(IFormFile file, StudentImage studentImage);
        bool StudentImageExist(string fileName);
    }
}

