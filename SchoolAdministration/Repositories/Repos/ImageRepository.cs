using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;

        public ImageRepository(IWebHostEnvironment webHostEnvironment,AppDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public async Task<IEnumerable<StudentImage>> GetAllStudentImages()
        {
            return await _context.StudentImages.ToListAsync();
        }

        public bool StudentImageExist(string fileName)
        {
            return _context.StudentImages.Any(p => p.FileName == fileName);                                                          
        }

        public async Task<StudentImage> Upload(IFormFile file, StudentImage studentImage)
        {
            var StudentImagesFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", "StudentImages");
            if (!Directory.Exists(StudentImagesFolder))
            {
                Directory.CreateDirectory(StudentImagesFolder);
            }
            var localPath = Path.Combine(StudentImagesFolder, $"{studentImage.FileName}{studentImage.FileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            studentImage.Url = localPath; 
            _context.StudentImages.Add(studentImage);
            await _context.SaveChangesAsync();

            return studentImage;
        }

      
    }
}
