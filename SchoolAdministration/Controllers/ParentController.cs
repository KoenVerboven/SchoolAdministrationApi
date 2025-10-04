using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Repositories.Repos;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepository _parentRepository;
        private readonly ILogger<ParentController> _logger;
        private readonly IMapper _mapper;

        public ParentController(IParentRepository parentRepository,ILogger<ParentController> logger, IMapper mapper)
        {
            _parentRepository = parentRepository;
            _logger = logger;
            _mapper = mapper;
        }

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
