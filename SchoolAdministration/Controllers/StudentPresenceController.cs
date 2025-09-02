using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPresenceController : ControllerBase
    {
        private const string controllerName = "StudentPresenceController";
        private readonly IStudentPresenceRepository _studentPresenceRepository;
        private readonly ILogger<StudentPresenceController> _logger;
        private readonly IMapper _mapper;

        public StudentPresenceController(IStudentPresenceRepository studentPresenceRepository, ILogger<StudentPresenceController> logger, IMapper mapper) { 
            _studentPresenceRepository = studentPresenceRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentPresenceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentPresenceDTO>>> GetAllStudentsPresenceAsync()
        {
            try
            {
                var allStudentsPresence = await _studentPresenceRepository.GetAllAsync();
                var studentsPresenceDTO = _mapper.Map<List<StudentPresenceDTO>>(allStudentsPresence);
                return Ok(studentsPresenceDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError("Message: {message}, Controller:{studentcontroller}, Action:{action}", ex.Message, controllerName, nameof(GetAllStudentsPresenceAsync));
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentPresenceDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentPresenceDTO>> GetStudentPresenceById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var studentPresence = await _studentPresenceRepository.GetByIdAsync(id);

            if (studentPresence == null)
            {
                return NotFound();
            }

            var studentPresenceDTO = _mapper.Map<StudentPresenceDTO>(studentPresence);
            return Ok(studentPresenceDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentPresenceDTO>> CreateStudentPresence(StudentPresenceCreateDTO studentPresenceCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            StudentPresence studentPresence = _mapper.Map<StudentPresence>(studentPresenceCreateDTO);

            await _studentPresenceRepository.AddStudentPresenceAsync(studentPresence);
            return CreatedAtAction(nameof(GetStudentPresenceById), new { id = studentPresence.Id }, studentPresence);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentPresence>> UpdateStudentPresenceAsync(int id, StudentPresenceUpdateDTO studentPresenceUpdateDTO)
        {
            if (id != studentPresenceUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            StudentPresence studentPresence = _mapper.Map<StudentPresence>(studentPresenceUpdateDTO);
            await _studentPresenceRepository.UpdateStudentPresenceAsync(studentPresence);
            return CreatedAtAction(nameof(GetStudentPresenceById), new { id = studentPresence.Id }, studentPresence);
        }

    }
}
