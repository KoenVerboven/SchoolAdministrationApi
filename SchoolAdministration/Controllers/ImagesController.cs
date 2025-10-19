using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
   
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImagesController(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        [HttpPost("UploadStudentImage")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage( IFormFile file, int studentId, string studentLastName, string studentFirstName,int createdByUserId) 
        {
            ValidateFileUpload(file, 10);

            if (ModelState.IsValid)
            {
                string fileName = studentId + "_" + studentLastName + "_" + studentFirstName;
                if (_imageRepository.StudentImageExist(fileName))
                {
                    return Conflict("An image with the same name already exists.");
                }

                var studentImage = new Models.Domain.StudentImage
                {
                    FileName = fileName,
                    FileExtension = Path.GetExtension(file.FileName).ToLower(),
                    Url = $"https://localhost:7213/images/studentimages/{fileName}{Path.GetExtension(file.FileName)}", //todo : replace hardcoded url
                    StudentId = studentId,
                    DateCreated = DateTime.UtcNow,
                    CreatedBy = createdByUserId
                };

                studentImage = await _imageRepository.Upload(file, studentImage);
                var studentImageDTO = _mapper.Map<StudentImageDTO>(studentImage);

                return Ok(studentImageDTO);
            }

            return BadRequest(ModelState);
        }

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
