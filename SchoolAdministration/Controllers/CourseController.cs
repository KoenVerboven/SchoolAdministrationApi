using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Models.Dtos;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;

       
        public CourseController(ICourseRepository courseRepository,ILogger<CourseController> logger,IMapper mapper)
        {
            _courseRepository = courseRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCoursers()
        {
            var allCourses = await _courseRepository.GetAllAsync();
            var coursesDTO = _mapper.Map<List<CourseDTO>>(allCourses);
            return Ok(coursesDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(CourseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CourseDTO>> GetCourseById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            var courseDTO = _mapper.Map<CourseDTO>(course);
            return Ok(courseDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CourseDTO>> CreateCourse(CourseCreateDTO courseCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Course course = _mapper.Map<Course>(courseCreateDTO);

            if (_courseRepository.CourseExist(course))
            {
                ModelState.AddModelError("CustomError", "Course already Exists!");
                return BadRequest(ModelState);
            }

            await _courseRepository.AddCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course );
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

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCourseAsync(int id,CourseUpdateDTO courseUpdateDTO)
        {
            if (id != courseUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Course course = _mapper.Map<Course>(courseUpdateDTO);
            await _courseRepository.UpdateCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course );
        }

        [HttpGet("getBySearch")]
        [ProducesResponseType(typeof(IEnumerable<CourseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> Search([FromQuery] CourseSearchParameters @params)
        {
            var courses = await _courseRepository.GetSearchAsync(@params);

            if (courses == null)
            {
                return NotFound();
            }
            var coursesDTO = _mapper.Map<List<CourseDTO>>(courses);
            return Ok(coursesDTO);
        }

    }
}
