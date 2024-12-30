using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamRepository _examRepository;

        public ExamController(IExamRepository examRepository  )
        {
            _examRepository = examRepository;        
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Student>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Exam>>> GetAllExamsAsync()
        {
            var exams = await _examRepository.GetAllAsync();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Exam>> GetExamById(int id)
        {
            var exam = _examRepository.GetByIdAsync(id);

            if(exam == null)
            {
                return NotFound();
            }

            return Ok(exam);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Exam>> CreateExam(Exam exam)
        {
            if(! ModelState.IsValid)
            {
                return BadRequest();
            }
            
            await _examRepository.AddExamAsync(exam);   
            return CreatedAtAction(nameof(GetExamById), new { id = exam.Id },exam);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteExamById(int id)
        {
            await _examRepository.DeleteExamAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Exam>> UpdateExamAsync(int id, Exam exam)
        {
            if( id != exam.Id)
            {
                return BadRequest();
            }

            if(! ModelState.IsValid)
            {
                return BadRequest();
            }
            
            await _examRepository.UpdateExamAsync(exam);
            return CreatedAtAction(nameof(GetExamById), new { id = exam.Id }, exam);
        }

    }
}
