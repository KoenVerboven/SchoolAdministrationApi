using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamRepository _examRepository;
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;

        public ExamController(IExamRepository examRepository, ILogger<CourseController> logger, IMapper mapper)
        {
            _examRepository = examRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExamDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ExamDTO>>> GetAllExamsAsync()
        {
            var exams = await _examRepository.GetAllAsync();
            var examsDTO = _mapper.Map<List<ExamDTO>>(exams);
            return Ok(examsDTO);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ExamDTO>> GetExamById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var exam = await _examRepository.GetByIdAsync(id);

            if(exam == null)
            {
                return NotFound();
            }

            var examDTO = _mapper.Map<ExamDTO>(exam);
            return Ok(examDTO);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ExamDTO>> CreateExam(ExamCreateDTO examCreateDTO)
        {
            if(! ModelState.IsValid)
            {
                return BadRequest();
            }

            Exam exam = _mapper.Map<Exam>(examCreateDTO);

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
        public async Task<ActionResult<Exam>> UpdateExamAsync(int id, ExamUpdateDTO examUpdateDTO)
        {
            if( id != examUpdateDTO.Id)
            {
                return BadRequest();
            }

            if(! ModelState.IsValid)
            {
                return BadRequest();
            }

            Exam exam = _mapper.Map<Exam>(examUpdateDTO);
            await _examRepository.UpdateExamAsync(exam);
            return CreatedAtAction(nameof(GetExamById), new { id = exam.Id }, exam);
        }

   }
}
