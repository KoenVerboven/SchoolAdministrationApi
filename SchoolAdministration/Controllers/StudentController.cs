using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;


namespace SchoolAdministration.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, 
            IStudentRepository studentRepository,
            IMapper mapper)
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
            _logger.LogInformation("Getting all the students.");
            var students = await  _studentRepository.GetAllAsync();
            var studentsDTO = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentsDTO);
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
                _logger.LogError("Get Student error with Id " + id);
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


        [HttpGet("getByName/{name}")]
        [ProducesResponseType(typeof(IEnumerable<Student>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentByName(string name)
        {
            var students = await _studentRepository.GetByNameAsync(name);
            return Ok(students);
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

            //if (await _studentRepository.GetByNameAsync(studentCreateDTO.FullName) != null)
            //{
            //    ModelState.AddModelError("CustomError", "Student already Exists!");
            //    return BadRequest(ModelState);
            //}

            Student student = _mapper.Map<Student>(studentCreateDTO);
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
        public async Task<ActionResult<Student>> UpdateStudentAsync(int id,StudentUpdateDTO studentUpdateDTO)
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

    }
}
