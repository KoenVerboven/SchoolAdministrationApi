using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ILogger<TeacherController> _logger;
        private readonly IMapper _mapper;

        public TeacherController(
            ITeacherRepository teacherRepository,
            ILogger<TeacherController> logger,
            IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<TeacherDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetAllTeachersAsync()
        {
            var allTeachers = await _teacherRepository.GetAllAsyn();
            var teachersDTO = _mapper.Map<List<TeacherDTO>>(allTeachers);
            return Ok(teachersDTO);
        }

        [HttpGet("GetAllTeachersSort/{sort}")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<TeacherDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetAllTeachersAsyncSort(string sort)
        {
            var allTeachers = await _teacherRepository.GetAllAsynSort(sort);
            var teachersDTO = _mapper.Map<List<TeacherDTO>>(allTeachers);
            return Ok(teachersDTO);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(TeacherDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TeacherDTO>>GetTeacherById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var teacher = await _teacherRepository.GetAsynById(id);

            if(teacher == null)
            {
                return NotFound();
            }

            var teacherDTO = _mapper.Map<TeacherDTO>(teacher);
            return Ok(teacherDTO);
        }

        [HttpPost]
        [Authorize(Roles ="admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TeacherDTO>> CreateTeacher(TeacherCreateDTO teacherCreateDTO)
        {
            if(! ModelState.IsValid)
            {
                return BadRequest();
            }

            Teacher teacher = _mapper.Map<Teacher>(teacherCreateDTO);

            if (_teacherRepository.TeacherExist(teacher))
            {
                ModelState.AddModelError("CustomError", "Teacher already Exists!");
                return BadRequest(ModelState);
            }

            await _teacherRepository.AddTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteTeacherById(int id)
        {
            await _teacherRepository.DeleteTeacherAsync(id);
            return NoContent();
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TeacherDTO>> UpdateTeacherAsync(int id, TeacherUpdateDTO teacherUpdateDTO)
        {
            if(id != teacherUpdateDTO.Id)
            {
                return BadRequest();    
            }
         
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Teacher teacher = _mapper.Map<Teacher>(teacherUpdateDTO);
            await _teacherRepository.UpdateTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }
    }

}
