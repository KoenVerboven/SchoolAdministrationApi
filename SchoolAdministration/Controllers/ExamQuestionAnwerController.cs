using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain.Exam.QuestionAnswer;
using SchoolAdministration.Repositories.Interfaces;


namespace SchoolAdministration.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExamQuestionAnwerController : ControllerBase
    {
        private readonly IExamQuestionAnwerRepository _examQuestionRepository;
        private readonly ILogger<ExamResultController> _logger;

        public ExamQuestionAnwerController(IExamQuestionAnwerRepository examQuestionRepository, ILogger<ExamResultController> logger)
        {
            _examQuestionRepository = examQuestionRepository;
            _logger = logger;
        }

     

        [HttpGet]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(typeof(IEnumerable<ExamQuestionAnwer>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ExamQuestionAnwer>>> GetAllExamQuestionsAsync()
        {
            var examQuestions = await _examQuestionRepository.GetAllAsync();
            return Ok(examQuestions);
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(typeof(ExamQuestionAnwer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ExamQuestionAnwer>> GetExamQuestionById(int id)
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
