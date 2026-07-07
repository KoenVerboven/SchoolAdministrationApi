using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain.Course;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Specifications;


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

        //be carefull with GetAllCourses with big data, it can cause performance issues,
        //consider using pagination or filtering (GetCourseByFilter is better for that)
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCourses()
        {
            List<CourseDTO> coursesDTO = new();

            _logger.LogInformation("Getting all courses");
            var allCourses = await _courseRepository.GetAllAsync();

            foreach(var course in allCourses)
            {
                coursesDTO.Add(new CourseDTO
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    CourseCode = course.CourseCode,
                    CourseDescription = course.CourseDescription,
                    StartDate = course.StartDate,
                    EndDate = course.EndDate,
                    CoursePrice = course.CoursePrice,
                    MaxNumberOfStudents = course.MaxNumberOfStudents,
                    Students = course.Students
                });
            }

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

            var courseDTO = new CourseDTO
            {
                Id = course.Id,
                CourseName = course.CourseName,
                CourseCode = course.CourseCode,
                CourseDescription = course.CourseDescription,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                CoursePrice = course.CoursePrice,
                MaxNumberOfStudents = course.MaxNumberOfStudents,
                Students = course.Students
            };

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

            var course = new Course
            {
                CourseName = courseCreateDTO.CourseName,
                CourseCode = courseCreateDTO.CourseCode,
                CourseDescription = courseCreateDTO.CourseDescription,
                StartDate = courseCreateDTO.StartDate ?? DateTime.Now,
                EndDate = courseCreateDTO.EndDate ?? DateTime.Now.AddMonths(1),
                CoursePrice = courseCreateDTO.CoursePrice,
                MaxNumberOfStudents = courseCreateDTO.MaxNumberOfStudents
            };

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

            var course = new Course
            {
                CourseName = courseUpdateDTO.CourseName,
                CourseCode = courseUpdateDTO.CourseCode,
                CourseDescription = courseUpdateDTO.CourseDescription,
                StartDate = courseUpdateDTO.StartDate ?? DateTime.Now,
                EndDate = courseUpdateDTO.EndDate ?? DateTime.Now.AddMonths(1),
                CoursePrice = courseUpdateDTO.CoursePrice,
                MaxNumberOfStudents = courseUpdateDTO.MaxNumberOfStudents
            };


            await _courseRepository.UpdateCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course );
        }

        [HttpGet("GetCourseByFilter")]
        [ProducesResponseType(typeof(IEnumerable<CourseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourseByFilter([FromQuery] CourseSearchParams @params)
        {
            List<CourseDTO> coursesDTO = new();
            var courses = await _courseRepository.GetCoursesByFilterAsync(@params);

            if (courses == null) 
            {
                return NotFound();
            }

            foreach (var course in courses)
            {
                coursesDTO.Add(new CourseDTO
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    CourseCode = course.CourseCode,
                    CourseDescription = course.CourseDescription,
                    StartDate = course.StartDate,
                    EndDate = course.EndDate,
                    CoursePrice = course.CoursePrice,
                    MaxNumberOfStudents = course.MaxNumberOfStudents,
                    Students = course.Students
                });
            }

            return Ok(coursesDTO);
        }

    }
}
