using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain.Exam.QuestionAnswer;
using SchoolAdministration.Repositories.Interfaces;


namespace SchoolAdministration.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class QAExamController : ControllerBase
    {
        private readonly IQAExamRepository _qAExamDetailRepository;
        private readonly ILogger<ExamResultController> _logger;

        public QAExamController(IQAExamRepository qAExamDetailRepository, ILogger<ExamResultController> logger)
        {
            _qAExamDetailRepository = qAExamDetailRepository;
            _logger = logger;
        }

     

        [HttpGet]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(typeof(IEnumerable<QAExamAnswer>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<QAExamAnswer>>> GetAllExamQuestionsAsync()
        {
            var examQuestions = await _qAExamDetailRepository.GetAllAsync();
            return Ok(examQuestions);
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(typeof(QAExamAnswer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QAExamAnswer>> GetExamQuestionById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var examQuestion = await _qAExamDetailRepository.GetByIdAsync(id);

            if (examQuestion == null)
            {
                return NotFound();
            }

            return Ok(examQuestion);
        }

    }
}
