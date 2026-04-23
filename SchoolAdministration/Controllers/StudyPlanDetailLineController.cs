using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyPlanDetailLineController : ControllerBase
    {
        private readonly IStudyPlanDetailLineRepository _studyPlanDetailLineRepository;

        public StudyPlanDetailLineController(IStudyPlanDetailLineRepository studyPlanDetailLineRepository)
        {
            _studyPlanDetailLineRepository = studyPlanDetailLineRepository;
        }

        [HttpGet("getStudyplanDetailLinesFilter")]
        [ProducesResponseType(typeof(IEnumerable<StudyPlanDetailLine>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task <ActionResult<IEnumerable<StudyPlanDetailLine>>> GetStudyplanDetailLinesFilter()//DateTime startDate
        {
            var startDate1 = new DateTime(2025, 4, 13);
            var allstudyPlanDetailLines = await _studyPlanDetailLineRepository.GetStudyPlanDetailLinesFilterAsync(startDate1);
            return Ok(allstudyPlanDetailLines);
        }

        //[HttpGet("getstudyPlanDetailLinesFilter/{startDate}")]
        //[ProducesResponseType(typeof(IEnumerable<studyPlanDetailLine>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<IEnumerable<studyPlanDetailLine>>> GetstudyPlanDetailLinesFilter(DateTime startDate)//DateTime startDate
        //{
        //    var startDate1 = new DateTime(2025, 4, 13);
        //    var allstudyPlanDetailLines = await _studyPlanDetailLineRepository.GetstudyPlanDetailLineFilterAsync(startDate1);
        //    return Ok(allstudyPlanDetailLines);
        //}



        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<StudyPlanDetailLine>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudyPlanDetailLine>>> GetAllStudyPlanDetailLines()
        {
            var allStudyPlanDetailLines = await _studyPlanDetailLineRepository.GetAllAsync();
            return Ok(allStudyPlanDetailLines);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudyPlanDetailLine), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudyPlanDetailLine>> GetStudyPlanDetailLineById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var studyPlanDetailLine = await _studyPlanDetailLineRepository.GetByIdAsync(id);

            if (studyPlanDetailLine == null)
            {
                return NotFound();
            }

            return Ok(studyPlanDetailLine);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudyPlanDetailLine>> CreateStudyPlanDetailLine(StudyPlanDetailLine studyPlanDetailLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //if (_studyPlanDetailLineRepository.(studyPlanDetailLine)) // Todo
            //{
            //    ModelState.AddModelError("CustomError", "StudyPlanDetailLine already Exists!");
            //    return BadRequest(ModelState);
            //}

            await _studyPlanDetailLineRepository.AddStudyPlanDetailLineAsync(studyPlanDetailLine);
            return CreatedAtAction(nameof(GetStudyPlanDetailLineById), new { id = studyPlanDetailLine.Id }, studyPlanDetailLine);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeletestudyPlanDetailLineById(int id)
        {
            await _studyPlanDetailLineRepository.DeleteStudyPlanDetailLineAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Student>> UpdateStudyPlanDetailLineAsync(int id, StudyPlanDetailLine studyPlanDetailLine)
        {
            if (id != studyPlanDetailLine.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _studyPlanDetailLineRepository.UpdateStudyPlanDetailLineAsync(studyPlanDetailLine);
            return CreatedAtAction(nameof(GetStudyPlanDetailLineById), new { id = studyPlanDetailLine.Id }, studyPlanDetailLine);
        }

    }
}
