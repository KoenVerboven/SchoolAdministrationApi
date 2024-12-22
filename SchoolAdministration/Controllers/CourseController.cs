using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories;

namespace SchoolAdministration.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Course>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCoursers()
        {
            var allCourses = await _courseRepository.GetAllAsync();
            return Ok(allCourses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _courseRepository.AddCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id, course });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            await _courseRepository.DeleteCourseAsync(id);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)] // 200 of 201 hier??
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCourseAsync(int id,Course course)
        {
            if(id != course.Id)
            {
                return BadRequest();
            }
            
            if (! ModelState.IsValid)
            {
                return BadRequest();
            }
            
            await _courseRepository.UpdateCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id, course });
        }

      
        //todo endpoint met filter op Course naam, starttijd, stoptijd,onlile cursus
        //todo sortering toevoegen
        //todo paging toevoegen

        //todo unitTesting toevoegen: max plaatsen beschikbaar aangevraagde plaats moet hierbinnen vallen.

        //todo relaties tussen tabellen bv student en courses
    }
}
