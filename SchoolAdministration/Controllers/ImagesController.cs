using Microsoft.AspNetCore.Mvc;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
    //    [HttpPost("upload")]
    //    public async Task<IActionResult> UploadImage([FromForm] IFormFile file,
    //        [FromForm] string fileName,
    //        [FromForm] int studentId) //add studentId later
    //    {
    //        ValidateFileUpload(file,10);

    //        if(ModelState.IsValid)
    //        {
    //            //File upload logic here
    //            var studentImage = new Models.Domain.StudentImage
    //            {
    //                FileName = fileName,
    //                FileExtension = Path.GetExtension(file.FileName).ToLower(),
    //                Url = $"https://example.com/images/{fileName}{Path.GetExtension(file.FileName)}",
    //                StudentId = studentId, 
    //                DateCreated = DateTime.UtcNow,
    //                CreatedBy = 1 // Replace with actual user ID
    //            };
    //        }
    //    }

        private void ValidateFileUpload(IFormFile file, int maxFileSizeInMB)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

            if(!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file type.");
            }
            if(file.Length > maxFileSizeInMB * 1024 * 1024) 
            {
                ModelState.AddModelError("file", $"File size exceeds the {maxFileSizeInMB}MB limit.");
            }
        }
    }
}
