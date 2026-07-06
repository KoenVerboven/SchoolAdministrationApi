using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain.Exam;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Specifications;


namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultRepository _examResultRepository;
        private readonly ILogger<ExamResultController> _logger;
        private readonly IMapper _mapper;

        public ExamResultController(IExamResultRepository examResultRepository, ILogger<ExamResultController> logger, IMapper mapper)
        {
            _examResultRepository = examResultRepository;
            _logger = logger;
            _mapper = mapper;
        }


        //The request url example : 
        //https://localhost:7213/api/ExamResult/GetExamResultsByFilter?StudentId=1&Sort=name&PageSize=10&PageNumber=1
        [HttpGet("GetExamResultsByFilter")]
        [ProducesResponseType(typeof(IEnumerable<ExamResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ExamResult>>> GetExamResultsByFilter([FromQuery] ExamenResultSearchParams @params)
        {
            var examResults = await _examResultRepository.GetExamResultsByFilterAsync(@params);

            if (examResults == null)
            {
                return NotFound();
            }
            var examResultsDTO = _mapper.Map<List<ExamResultDTO>>(examResults);
            return Ok(examResultsDTO    );
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
