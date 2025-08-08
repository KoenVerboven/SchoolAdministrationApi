using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;


namespace SchoolAdministration.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExamQuestionController : ControllerBase
    {
        private readonly IExamQuestionRepository _examQuestionRepository;
        private readonly ILogger<ExamResultController> _logger;

        public ExamQuestionController(IExamQuestionRepository examQuestionRepository, ILogger<ExamResultController> logger)
        {
            _examQuestionRepository = examQuestionRepository;
            _logger = logger;
        }

     

        [HttpGet]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(typeof(IEnumerable<ExamQuestion>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ExamQuestion>>> GetAllExamQuestionsAsync()
        {
            var examQuestions = await _examQuestionRepository.GetAllExamQuestionsAsync();
            return Ok(examQuestions);
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(typeof(ExamQuestion), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ExamQuestion>> GetExamQuestionById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var examQuestion = await _examQuestionRepository.GetByIdAsync(id);

            if (examQuestion == null)
            {
                return NotFound();
            }

            return Ok(examQuestion);
        }

    }
}
