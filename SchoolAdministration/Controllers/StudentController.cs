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
        protected APIResponse _response;
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<StudentController> _logger;
        private readonly IMapper _mapper;

        public StudentController(
            IStudentRepository studentRepository,
            ILogger<StudentController> logger,
            IMapper mapper)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> GetAllStudentsAsync()
        {
            try
            {
                var allStudents = await _studentRepository.GetAllAsync();
                var studentsDTO = _mapper.Map<List<StudentDTO>>(allStudents);
                return Ok(studentsDTO);
            }
            catch (Exception ex)
            {
                WriteMessageToLog("An eror occured during GetAllStudentsAsync", ex.Message);
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
                WriteMessageToLog("An eror occured during GetStudentById, personId = {id}", id.ToString());
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


        public async Task<ActionResult<StudentExamsResultDTO>> GetStudentExamResultsById(int studentId)
        {
            return null;//todo
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


        private void WriteMessageToLog(string message, string? messageDetail)//Todo : place in special class
        {
            _logger.LogInformation("ERROR: {message}" , message);
            _logger.LogInformation("Logged on {datetime}", DateTime.Now);
            if (messageDetail != null) 
                _logger.LogInformation(messageDetail);
        }

    }
}
