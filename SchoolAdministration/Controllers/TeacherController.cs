using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.ManualMapper;
using SchoolAdministration.Models.Domain.Teacher;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Specifications;

//POC Manual Mapping
namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ITeacherRepository teacherRepository,ILogger<TeacherController> logger)
        {
            _teacherRepository = teacherRepository;
            _logger = logger;
        }

        [HttpGet]
        //[Authorize]
        [ProducesResponseType(typeof(IEnumerable<TeacherDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetAllTeachersAsync()
        {
            var allTeachers = await _teacherRepository.GetAllAsyn();
            var teachersDTO = allTeachers.MapTeachersToTeacherDtos();
            return Ok(teachersDTO);
        }

        //obsolete : use GetTeacherByFilter instead
        [HttpGet("getAllTeachersSort/{sort}")]
        //[Authorize]
        [ProducesResponseType(typeof(IEnumerable<TeacherDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetAllTeachersAsyncSort(string sort)
        {
            List<TeacherDTO> teachersDTO = new();
            var allTeachers = await _teacherRepository.GetAllAsynSort(sort);

            foreach (var teacher in allTeachers)
            {
                teachersDTO.Add(new TeacherDTO
                {
                    Id = teacher.Id,
                    LastName = teacher.LastName,
                    FirstName = teacher.FirstName,
                    Gender = teacher.Gender,
                    Email = teacher.Email,
                    DateOfBirth = teacher.DateOfBirth,
                    Phone = teacher.Phone,
                    HireDate = teacher.HireDate,
                    MaritalStatusId = teacher.MaritalStatusId,
                    TeacherAddresses = teacher.TeacherAddresses
                });
            }
            return Ok(teachersDTO);
        }

        //obsolete : use GetTeacherByFilter instead
        [HttpGet("getAllFilter/{sort}")]
        //[Authorize]
        [ProducesResponseType(typeof(IEnumerable<TeacherDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetAllAsyncFilter(string sort, int pageSize, int pageNumber, int zipCode = 0) //add filter object
        {
            var allTeachers = await _teacherRepository.GetFilterAsyn(sort, pageSize: pageSize, pageNumber: pageNumber);
            var teachersDTO = allTeachers.MapTeachersToTeacherDtos();
            return Ok(teachersDTO);
        }

        [HttpGet("GetTeacherByFilter")]
        //[Authorize]
        [ProducesResponseType(typeof(IEnumerable<TeacherDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetTeacherByFilter([FromQuery] TeacherSearchParams teacherSearchParams)
        {
            var teachers = await _teacherRepository.GetTeachersByTeachersSearchParamsFilterAsync(teacherSearchParams);
            List<TeacherDTO> teachersDTO = new();
            foreach (var teacher in teachers)
            {
                teachersDTO.Add(new TeacherDTO
                {
                    Id = teacher.Id,
                    LastName = teacher.LastName,
                    FirstName = teacher.FirstName,
                    Gender = teacher.Gender,
                    Email = teacher.Email,
                    DateOfBirth = teacher.DateOfBirth,
                    Phone = teacher.Phone,
                    HireDate = teacher.HireDate,
                    MaritalStatusId = teacher.MaritalStatusId,
                    TeacherAddresses = teacher.TeacherAddresses
                });
            }
            return Ok(teachersDTO);
        }

        [HttpGet("{id}")]
        //[Authorize]
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

            var teacherDTO = teacher.MapTeacherToTeacherDto();
            return Ok(teacherDTO);
        }

        [HttpPost]
        //[Authorize(Roles ="admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TeacherDTO>> CreateTeacher(TeacherCreateDTO teacherCreateDTO)
        {
            if(! ModelState.IsValid)
            {
                return BadRequest();
            }

            var teacher = teacherCreateDTO.MapTeacherCreateDtoToTeacher();

            if (_teacherRepository.TeacherExist(teacher))
            {
                ModelState.AddModelError("CustomError", "Teacher already Exists!");
                return BadRequest(ModelState);
            }

            await _teacherRepository.AddTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }

        [HttpDelete("{id}")]
       // [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteTeacherById(int id)
        {
            await _teacherRepository.DeleteTeacherAsync(id);
            return NoContent();
        }


        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
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

            var teacher = teacherUpdateDTO.MapTeacherUpdateDtoToTeacher();

            await _teacherRepository.UpdateTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }
    }

}
