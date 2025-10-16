using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext _context;

        public ImageRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<StudentImage> Upload(IFormFile file, StudentImage studentImage)
        {
            //1 upload the image to map StudentImages
            var localPath = "";//doto : upload to local path get the URL

            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            //2 update database with image details
            //todo: update the database with image details
            var urlPath = "";

            studentImage.Url = urlPath; //set the URL to the local path or cloud URL

            //await _context.StudentImages.Add(studentImage);
            await _context.SaveChangesAsync();

            return studentImage;
        }
    }
}
