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
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly ILogger<StudentPresenceController> _logger;
        private readonly IMapper _mapper;

        public IStudentRepository StudentRepository { get; }

        public StudentPresenceController(IStudentPresenceRepository studentPresenceRepository, IStudentRepository studentRepository, IClassRepository classRepository ,ILogger<StudentPresenceController> logger, IMapper mapper) { 
            _studentPresenceRepository = studentPresenceRepository;
            _studentRepository = studentRepository;
            _classRepository = classRepository;
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
        public async Task<ActionResult<StudentPresenceDTO>> AddStudentPresence(StudentPresenceCreateDTO studentPresenceCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid ModelState");
            }
            if (studentPresenceCreateDTO == null)
            {
                return BadRequest("No studentPresence provided");
            }

            StudentPresence studentPresence = _mapper.Map<StudentPresence>(studentPresenceCreateDTO);

            await _studentPresenceRepository.AddStudentPresenceAsync(studentPresence);
            return CreatedAtAction(nameof(GetStudentPresenceById), new { id = studentPresence.Id }, studentPresence);
        }
       
        [HttpPost("AddStudentsPresenceList")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentPresenceDTO>> AddStudentsPresence([FromBody] List<StudentPresenceCreateDTO> studentsPresenceCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid modelState");
            }
            if(studentsPresenceCreateDTO == null || studentsPresenceCreateDTO.Count == 0)
            {
                return BadRequest("No studentsPresence provided");
            }

            List<StudentPresence> studentsPresenceList = _mapper.Map<List<StudentPresence>>(studentsPresenceCreateDTO);

            await _studentPresenceRepository.AddStudentsPresenceAsync(studentsPresenceList);
            return CreatedAtAction( nameof(AddStudentsPresence), new { });
        }
      

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentPresence>> UpdateStudentPresenceAsync(int id, StudentPresenceUpdateDTO studentPresenceUpdateDTO)
        {
            if (id != studentPresenceUpdateDTO.Id)
            {
                return BadRequest("Provided Id is not ok");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid modelState");
            }

            StudentPresence studentPresence = _mapper.Map<StudentPresence>(studentPresenceUpdateDTO);
            await _studentPresenceRepository.UpdateStudentPresenceAsync(studentPresence);
            return CreatedAtAction(nameof(GetStudentPresenceById), new { id = studentPresence.Id }, studentPresence);
        }

        [HttpGet("getStudents")]
        [ProducesResponseType(typeof(IEnumerable<StudentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudentsAsync()
        {
            try
            {
                var allStudents = await _studentRepository.GetAllAsync();
                var studentsDTO = _mapper.Map<List<StudentDTO>>(allStudents);
                return Ok(studentsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError("Message: {message}, Controller:{studentcontroller}, Action:{action}", ex.Message, controllerName, nameof(GetAllStudentsAsync));
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getSchoolClasses")]
        [ProducesResponseType(typeof(IEnumerable<ClassDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SchoolClass>>> GetSchoolClassesAsync(int SchoolId)
        {
            try
            {
                var schoolClasses = await _classRepository.GetAllAsync();//todo : add filter schoolId
                var classesDTO = _mapper.Map<List<ClassDTO>>(schoolClasses);
                return Ok(classesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError("Message: {message}, Controller:{studentcontroller}, Action:{action}", ex.Message, controllerName, nameof(GetSchoolClassesAsync));
                return BadRequest(ex.Message);
            }
        }


    }
}
