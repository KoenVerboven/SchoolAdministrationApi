using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Dtos;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IExamRepository _examRepository;
        private readonly ILogger<DashboardController> _logger;
        private readonly IMapper _mapper;

        public DashboardController(
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository,
            ICourseRepository courseRepository,
            IUserRepository userRepository,
            IExamRepository examRepository,
            ILogger<DashboardController> logger,
            IMapper mapper
            )
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _examRepository = examRepository;
            _logger = logger;
            _mapper = mapper;
        }

      
        [HttpGet("getStudentCount")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> StudentCountAsync()
        {
            return await _studentRepository.CountAsync();
        }

       
        [HttpGet("getTeacherCount")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<int> TeacherCountAsync()
        {
            return await _teacherRepository.CountAsync();
        }

      
        [HttpGet("getUserCount")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<int> UserCountAsync()
        {
            return await _userRepository.CountAsync();
        }

        [HttpGet("getCourseCount")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<int> CourseCountAsync()
        {
            return await _courseRepository.CountAsync();
        }

       
        [HttpGet("getExamCount")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<int> ExamCountAsync()
        {
            return await _examRepository.CountAsync();
        }

    }
}
