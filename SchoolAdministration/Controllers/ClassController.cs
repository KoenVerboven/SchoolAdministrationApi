using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.ManualMapper;
using SchoolAdministration.Models.Domain.School;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;

//Manual Mapping
namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;

        public ClassController(IClassRepository  classRepository)
        {
            _classRepository = classRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClassDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetAllClasses()
        {
            var allClasses = await _classRepository.GetAllAsync();
            var classesDTO = allClasses.MapSchoolClassToClassClassDtos();
            return Ok(classesDTO);
        }


        [HttpGet("getClassesByDepartmentIdAsync/{departmentId}")]
        [ProducesResponseType(typeof(IEnumerable<ClassDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetClassesByDepartmentId(int departmentId)
        {
            var allClasses = await _classRepository.GetClassByDepartmentIdAsync(departmentId);
            var classesDTO = allClasses.MapSchoolClassToClassClassDtos();
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

            var classDTO = schoolclass.MapSchoolClassToSchoolClassDto();
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

            SchoolClass schoolclass = classCreateDTO.MapClassCreateDtoToSchoolClass();

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

            SchoolClass schoolClass = classUpdateDTO.MapClassUpdateDtoToSchoolClass();
            await _classRepository.UpdateClassAsync(schoolClass);
            return CreatedAtAction(nameof(GetClassById), new { id = schoolClass.Id }, schoolClass);
        }


    }
}
