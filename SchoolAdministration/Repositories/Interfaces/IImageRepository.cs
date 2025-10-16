using SchoolAdministration.Models.Domain;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<StudentImage>Upload(IFormFile file, StudentImage studentImage);
    }
}

