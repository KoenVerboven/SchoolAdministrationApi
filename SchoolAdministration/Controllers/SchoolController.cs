using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;

        public SchoolController(ISchoolRepository schoolRepository, IMapper mapper )
        {
           _schoolRepository = schoolRepository;
           _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SchoolDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SchoolDTO>>> GetAllSchoolsAsync()
        {
            var schools = await _schoolRepository.GetAllAsync();
            var schoolsDTO = _mapper.Map<List<SchoolDTO>>(schools);
            return Ok(schoolsDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(SchoolDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SchoolDTO>> GetSchoolById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var school = await _schoolRepository.GetByIdAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            var SchoolDTO = _mapper.Map<SchoolDTO>(school);
            return Ok(SchoolDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SchoolDTO>> CreateSchool(SchoolCreateDTO schoolCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            School school = _mapper.Map<School>(schoolCreateDTO);

            if (_schoolRepository.SchoolExist(schoolCreateDTO))
            {
                ModelState.AddModelError("CustomError", "School already Exists!");
                return BadRequest(ModelState);
            }

            await _schoolRepository.AddSchoolAsync(school);
            return CreatedAtAction(nameof(GetSchoolById), new { id = school.Id }, school);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteSchool(int id)
        {
            await _schoolRepository.DeleteSchoolAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCourseAsync(int id,  SchoolUpdateDTO schoolUpdateDTO)
        {
            if (id != schoolUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            School school = _mapper.Map<School>(schoolUpdateDTO);
            await _schoolRepository.UpdateSchoolAsync(school);
            return CreatedAtAction(nameof(GetSchoolById), new { id = school.Id }, school);
        }


    }
}
