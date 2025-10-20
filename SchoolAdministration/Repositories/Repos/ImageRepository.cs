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

        public bool StudentImageExist(string fileName)
        {
            return _context.StudentImages.Any(p => p.FileName == fileName);                                                          
        }

        public async Task<StudentImage> Upload(IFormFile file, StudentImage studentImage)
        {
            var localPath = Path.Combine(_webHostEnvironment.ContentRootPath,"Images\\StudentImages",$"{studentImage.FileName}{studentImage.FileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            var urlPath = "https://localhost:7213/images/1_Verboven_Koen.jpg";//todo: set the correct url path
            studentImage.Url = urlPath; 
            _context.StudentImages.Add(studentImage);
            await _context.SaveChangesAsync();

            return studentImage;
        }
    }
}
