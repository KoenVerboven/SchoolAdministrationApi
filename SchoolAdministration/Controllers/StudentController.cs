using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories;


namespace SchoolAdministration.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Student>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudentsAsync()
        {
            var allEmployees = await _studentRepository.GetAllAsync();
            
            return Ok(allEmployees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Student>>GetStudentById(int id)
        {
            var employee = await _studentRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            if (! ModelState.IsValid)
            {
                return BadRequest();
            }
            
            await _studentRepository.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new {id = student.Id}, student); //Status 201
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteStudentById(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
            return NoContent();//Status 204
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)] // 200 of 201 hier??
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Student>>UpdateStudentAsync(int id,Student student)
        {
            if(id != student.Id)
            {
                return BadRequest();//Status 400
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _studentRepository.UpdateStudentAsync(student);

            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student); //Status 201
        }

    }
}
