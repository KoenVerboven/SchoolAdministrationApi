using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{

    [Route("api/[Controller]")]
    [ApiVersion("1.0")] 
    [ApiController]
    public class StudentController : ControllerBase
    {
        private const string controllerName = "StudentController";
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<StudentController> _logger;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository,ILogger<StudentController> logger,IMapper mapper)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudentsAsync()
        {
            try
            {
                var allStudents = await _studentRepository.GetAllAsync();
                var studentsDTO = _mapper.Map<List<StudentDTO>>(allStudents);
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

            var studentDTO = _mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }

        [HttpGet("GetStudentsExamResults")]
        public async Task<ActionResult<IEnumerable<StudentExamsResultDTO>>> GetStudentsExamResults()
        {
            var studentExamsResultDTOList = await _studentRepository.GetStudentExamResultsAsync();
            return Ok(studentExamsResultDTOList);
        }


        [HttpGet("getByNameStartWith/{name}")]
        [ProducesResponseType(typeof(IEnumerable<StudentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudentByNameStartWith(string name)
        {
            var students = await _studentRepository.GetByNameStartWithAsync(name);
            var studentsDTO = _mapper.Map<IEnumerable<StudentDTO>>(students);
            return Ok(studentsDTO);
        }

        //[HttpGet("getStudentByFilter1")]
        //[ProducesResponseType(typeof(IEnumerable<StudentDTO>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<IEnumerable<StudentDTO>>> getStudentByFilter1([FromQuery] StudentSpecParams studentSpecParams)
        //{
        //    var students = await _studentRepository.GetFilterAsync1(studentSpecParams);
        //    var studentsDTO = _mapper.Map<IEnumerable<StudentDTO>>(students);
        //    return Ok(studentsDTO);
        //}

        [HttpGet("getStudentByFilter")]
        [ProducesResponseType(typeof(IEnumerable<StudentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> getStudentByFilter([FromQuery] string? Name,string? Email, int ZipCode, string Sort, int PageSize, int PageNumber)
        {
            var students = await _studentRepository.GetFilterAsync(Name,Email, ZipCode,Sort,PageSize,PageNumber);
            var studentsDTO = _mapper.Map<IEnumerable<StudentDTO>>(students);
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

            Student student = _mapper.Map<Student>(studentCreateDTO);

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

            Student student = _mapper.Map<Student>(studentUpdateDTO);
            await _studentRepository.UpdateStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student); 
        }

        [HttpGet("getStudentCount")]
        public async Task<int> StudentCountAsync()
        {
            return await _studentRepository.CountAsync();
        }

        [HttpGet("getStudentFilterCount")]
        public async Task<int> StudentFilterCountAsync2(string? Name, string? Email, int ZipCode)
        {
            return await _studentRepository.CountFilterAsync(Name,Email,ZipCode);
        }
    }
}
