using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IGenericRepository<School> _repository;
        private readonly IMapper _mapper;

        public SchoolController(IGenericRepository<School> repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SchoolDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SchoolDTO>>> GetAllSchoolsAsync()
        {
            var schools = await _repository.ListAllAsync();
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

            var school = await _repository.GetByIdAsync(id);

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

            //if (_schoolRepository.SchoolExist(schoolCreateDTO))
            //{
            //ModelState.AddModelError("CustomError", "School already Exists!");
            //return BadRequest(ModelState);
            //}

            _repository.Add(school);
            await _repository.SaveAllAsync();
            return CreatedAtAction(nameof(GetSchoolById), new { id = school.Id }, school);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteSchool(int id)
        {
            var school = await _repository.GetByIdAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            _repository.Remove(school);
            await _repository.SaveAllAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCourseAsync(int id, SchoolUpdateDTO schoolUpdateDTO)
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
            _repository.Update(school);
            await _repository.SaveAllAsync();
            return CreatedAtAction(nameof(GetSchoolById), new { id = school.Id }, school);
        }


    }
}
