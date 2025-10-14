using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Repositories.Interfaces;


namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultRepository _examResultRepository;
        private readonly ILogger<ExamResultController> _logger;

        public ExamResultController(IExamResultRepository examResultRepository, ILogger<ExamResultController> logger)
        {
            _examResultRepository = examResultRepository;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExamResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ExamResult>>> GetAllExamResultAsync()
        {
            var examResults = await _examResultRepository.GetAllExamResultsAsync();
            return Ok(examResults);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExamResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ExamResult>> GetExamResultById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var examResult = await _examResultRepository.GetByIdAsync(id);

            if (examResult == null)
            {
                return NotFound();
            }

            return Ok(examResult);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ExamResult>> CreateExamResult(ExamResult examResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _examResultRepository.AddExamResultAsync(examResult);
            return CreatedAtAction(nameof(GetExamResultById), new { id = examResult.Id }, examResult);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteExamById(int id)
        {
            await _examResultRepository.DeleteExamResultAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ExamResult>> UpdateExamResultAsync(int id, ExamResult examResult)
        {
            if (id != examResult.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _examResultRepository.UpdateExamResultAsync(examResult);
            return CreatedAtAction(nameof(GetExamResultById), new { id = examResult.Id }, examResult);
        }
    }
}
