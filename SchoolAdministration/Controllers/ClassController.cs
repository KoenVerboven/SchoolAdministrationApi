using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Models.Dtos;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Repositories.Repos;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassController(IClassRepository  classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClassDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetAllClasses()
        {
            var allClasses = await _classRepository.GetAllAsync();
            var classesDTO = _mapper.Map<List<ClassDTO>>(allClasses);
            return Ok(classesDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(ClassDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CourseDTO>> GetClassById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var schoolclass = await _classRepository.GetByIdAsync(id);

            if (schoolclass == null)
            {
                return NotFound();
            }

            var classDTO = _mapper.Map<ClassDTO>(schoolclass);
            return Ok(classDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClassDTO>> CreateClass(ClassCreateDTO classCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            SchoolClass schoolclass = _mapper.Map<SchoolClass>(classCreateDTO);

            //if (_classRepository.ClassExist(schoolclass))
            //{
                //ModelState.AddModelError("CustomError", "Class already Exists!");
                //return BadRequest(ModelState);
            //}

            await _classRepository.AddClassAsync(schoolclass);
            return CreatedAtAction(nameof(GetClassById), new { id = schoolclass.Id }, schoolclass);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteClass(int id)
        {
            await _classRepository.DeleteClassAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateClassAsync(int id, ClassUpdateDTO classUpdateDTO)
        {
            if (id != classUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            SchoolClass schoolClass = _mapper.Map<SchoolClass>(classUpdateDTO);
            await _classRepository.UpdateClassAsync(schoolClass);
            return CreatedAtAction(nameof(GetClassById), new { id = schoolClass.Id }, schoolClass);
        }


    }
}
