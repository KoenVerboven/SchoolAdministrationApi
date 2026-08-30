using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController(IParentRepository parentRepository, ILogger<ParentController> logger, IMapper mapper) : ControllerBase
    {
        private readonly IParentRepository _parentRepository = parentRepository;
        private readonly ILogger<ParentController> _logger = logger;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        //[Authorize]
        [ProducesResponseType(typeof(IEnumerable<TeacherDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ParentDTO>>> GetAllParentsAsync()
        {
            var allParents = await _parentRepository.GetAllAsync();
            var parentsDTO = _mapper.Map<List<ParentDTO>>(allParents);
            return Ok(parentsDTO);
        }

        [HttpGet("{id}")]
        //[Authorize]
        [ProducesResponseType(typeof(TeacherDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ParentDTO>> GetParentById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var parent = await _parentRepository.GetByIdAsync(id);

            if (parent == null)
            {
                return NotFound();
            }

            var parentDTO = _mapper.Map<ParentDTO>(parent);
            return Ok(parentDTO);
        }


        [HttpPost]
        //[Authorize(Roles ="admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TeacherDTO>> CreateParent(ParentCreateDTO parentCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Parent parent = _mapper.Map<Parent>(parentCreateDTO);

            //if (_parentRepository.ParentExist(parent))
            //{
            //    ModelState.AddModelError("CustomError", "Parent already Exists!");
            //    return BadRequest(ModelState);
            //}

            await _parentRepository.AddParentAsync(parent);
            return CreatedAtAction(nameof(GetParentById), new { id = parent.Id }, parent);
        }


        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ParentDTO>> UpdateParentAsync(int id, ParentUpdateDTO parentUpdateDTO)
        {
            if (id != parentUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Parent parent = _mapper.Map<Parent>(parentUpdateDTO);
            await _parentRepository.UpdateParentAsync(parent);
            return CreatedAtAction(nameof(GetParentById), new { id = parent.Id }, parent);
        }

    }
}
