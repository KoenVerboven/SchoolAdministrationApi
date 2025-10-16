using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Repositories.Repos;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetAllDepartmentssAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            var departmentsDTO = _mapper.Map<List<DepartmentDTO>>(departments);
            return Ok(departmentsDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(DepartmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DepartmentDTO>> GetDepartmentById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var course = await _departmentRepository.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            var departmentDTO = _mapper.Map<DepartmentDTO>(course);
            return Ok(departmentDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DepartmentDTO>> CreateDepartment(DepartmentCreateDTO departmentCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            SchoolDepartment deparment = _mapper.Map<SchoolDepartment>(departmentCreateDTO);

            //if (_departmentRepository.DepartmentExists(department))
            //{
                //ModelState.AddModelError("CustomError", "Department already Exists!");
                //return BadRequest(ModelState);
            //}

            await _departmentRepository.AddDepartmentAsync(deparment);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = deparment.Id }, deparment);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateDepartmentAsync(int id, SchoolUpdateDTO schoolUpdateDTO)
        {
            if (id != schoolUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            SchoolDepartment department = _mapper.Map<SchoolDepartment>(schoolUpdateDTO);
            await _departmentRepository.UpdateDepartmentAsync(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }
    }
}
