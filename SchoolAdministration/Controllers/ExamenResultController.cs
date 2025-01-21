using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Repositories.Repos;


namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenResultController : ControllerBase
    {
        private readonly IExamResultRepository _examResultRepository;

        public ExamenResultController(IExamResultRepository examResultRepository)
        {
            _examResultRepository = examResultRepository;
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
            var examResult = _examResultRepository.GetByIdAsync(id);

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
