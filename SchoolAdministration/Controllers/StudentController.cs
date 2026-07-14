using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Specifications;

namespace SchoolAdministration.Controllers
{

    [Route("api/[Controller]")]
    [ApiVersion("1.0")] 
    [ApiController]
    public class StudentController(IStudentRepository studentRepository, ILogger<StudentController> logger) : ControllerBase
    {
        private const string controllerName = "StudentController";

        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly ILogger<StudentController> _logger = logger;
 
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudentsAsync()
        {
            try
            {
                var allStudents = await _studentRepository.GetAllAsync();
                var studentsDTO = allStudents.Select(student => new StudentDTO
                {
                    Id = student.Id,
                    LastName = student.LastName,
                    FirstName = student.FirstName,
                    Gender = student.Gender,
                    Email = student.Email,
                    DateOfBirth = student.DateOfBirth,
                    Phone = student.Phone,
                    RegistrationDate = student.RegistrationDate,
                    StudentAddresses = student.StudentAddresses,
                }).ToList();

                return Ok(studentsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError("Message: {message}, Controller:{studentcontroller}, Action:{action}", ex.Message, controllerName,nameof(GetAllStudentsAsync));
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>>GetStudentById(int id)
        {
            if(id == 0)
            {
                _logger.LogInformation("StudentId can not be 0");
                return BadRequest();
            }

            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Gender = student.Gender,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                Phone = student.Phone,
                RegistrationDate = student.RegistrationDate,
                StudentAddresses = student.StudentAddresses
            };

            return Ok(studentDTO);
        }

        [HttpGet("getStudentAddresses/{studentId}")]
        public async Task<ActionResult<IEnumerable<StudentAddressDTO>>> GetStudentAddresses(int studentId)
        {
            if (studentId == 0)
            {
                _logger.LogInformation("StudentId can not be 0");
                return BadRequest();
            }

            var student = await _studentRepository.GetByIdAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }

            var studentAddresses = await _studentRepository.GetStudentAddressesAsync(studentId);
            return Ok(studentAddresses);
        }

        [HttpGet("getStudentsExamResults")]
        public async Task<ActionResult<IEnumerable<StudentExamsResultDTO>>> GetStudentsExamResults()
        {
            var studentExamsResultDTOList = await _studentRepository.GetStudentExamResultsAsync();
            return Ok(studentExamsResultDTOList);
        }

        //todo : endpoint is obsolete, need to remove it in future
        [HttpGet("getByNameStartWith/{name}")]
        [ProducesResponseType(typeof(IEnumerable<StudentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudentByNameStartWith(string name)
        {
            var students = await _studentRepository.GetByNameStartWithAsync(name);
            var studentsDTO = students.Select(student => new StudentDTO
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Gender = student.Gender,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                Phone = student.Phone,
                RegistrationDate = student.RegistrationDate,
                StudentAddresses = student.StudentAddresses,
            }).ToList();

            return Ok(studentsDTO);
        }

        [HttpGet("getStudentByFilter")]
        [ProducesResponseType(typeof(IEnumerable<StudentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudentByFilter([FromQuery] StudentSearchParams studentSearchParams)
        {
            var students = await _studentRepository.GetStudentsByFilterAsync(studentSearchParams);
            var studentsDTO = students.Select(student => new StudentDTO
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Gender = student.Gender,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                Phone = student.Phone,
                RegistrationDate = student.RegistrationDate,
                StudentAddresses = student.StudentAddresses,
            }).ToList();

            return Ok(studentsDTO);
        }

        //todo : endpoint is obsolete, need to remove it in future
        [HttpGet("getStudentByFilterOld")]
        [ProducesResponseType(typeof(IEnumerable<StudentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudentByFilterOld([FromQuery] string? Name, string? Email, int ZipCode, string Sort, int PageSize, int PageNumber)
        {
            var students = await _studentRepository.GetStudentsByFilterAsyncOld(Name, Email, ZipCode, Sort, PageSize, PageNumber);
            var studentsDTO = students.Select(student => new StudentDTO
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Gender = student.Gender,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                Phone = student.Phone,
                RegistrationDate = student.RegistrationDate,
                StudentAddresses = student.StudentAddresses,
            }).ToList();

            return Ok(studentsDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentCreateDTO>> CreateStudent(StudentCreateDTO studentCreateDTO)
        {
            if (! ModelState.IsValid)
            {
                return BadRequest();
            }

            var student = new Student
            {
                LastName = studentCreateDTO.LastName,
                FirstName = studentCreateDTO.FirstName,
                Gender = studentCreateDTO.Gender,
                Email = studentCreateDTO.Email,
                DateOfBirth = studentCreateDTO.DateOfBirth,
                Phone = studentCreateDTO.Phone,
                CreatedBy = studentCreateDTO.CreatedBy,
                CreatedDate = DateTime.Now,
            };
  
            if (_studentRepository.StudentExist(student))
            {
                ModelState.AddModelError("CustomError", "Student already Exists!");
                return BadRequest(ModelState);
            }
            
            await _studentRepository.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new {id = student.Id}, student);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteStudentById(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> UpdateStudentAsync(int id,StudentUpdateDTO studentUpdateDTO)
        {
            if(id != studentUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var student = new Student
            {
                Id = studentUpdateDTO.Id,
                LastName = studentUpdateDTO.LastName,
                FirstName = studentUpdateDTO.FirstName,
                Gender = studentUpdateDTO.Gender,
                Email = studentUpdateDTO.Email,
                DateOfBirth = studentUpdateDTO.DateOfBirth,
                Phone = studentUpdateDTO.Phone,
                UpdatedBy = studentUpdateDTO.UpdatedBy,
                UpdateDate = DateTime.Now,
            };
        
            await _studentRepository.UpdateStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student); 
        }

        [HttpGet("getStudentCount")]
        public async Task<int> GetStudentCount()
        {
            return await _studentRepository.CountAsync();
        }

        [HttpGet("getStudentFilterCount")]
        public async Task<int> GetStudentFilterCount(string? Name, string? Email, int ZipCode)
        {
            return await _studentRepository.CountStudentsByFilterAsync(Name,Email,ZipCode);
        }


        [HttpGet("getStudentCourses/{id}")]
        [ProducesResponseType(typeof(StudentCourseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentCourseDTO>> GetStudentCourses(int id)
        {
            if (id == 0)
            {
                _logger.LogInformation("StudentId can not be 0");
                return BadRequest();
            }

            var studentCourses = await _studentRepository.GetStudentCoursesAsync(id);

            if (studentCourses == null)
            {
                return NotFound();
            }

            return Ok(studentCourses);
        }

    }
}
