using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
                _teacherRepository = teacherRepository;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Teacher>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]// klopt dit voor get all?
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeachersAsync()
        {
            var allTeachers = await _teacherRepository.GetAllAsyn();
            return Ok(allTeachers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Teacher), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //klopt dit? weg doen (alle controllers)
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Teacher>>GetTeacherById(int id)
        {
            var teacher = await _teacherRepository.GetAsynById(id);

            if(teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Teacher>> CreateTeacher(Teacher teacher)
        {
            if(! ModelState.IsValid)
            {
                return BadRequest();
            }
            
            await _teacherRepository.AddTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new {id= teacher.Id, teacher});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacherById(int id)
        {
            await _teacherRepository.DeleteTeacherAsync(id);
            return NoContent();
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Teacher>> UpdateTeacherAsync(int id, Teacher teacher)
        {
            if(id != teacher.Id)
            {
                return BadRequest();    
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _teacherRepository.UpdateTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }
    }

}
