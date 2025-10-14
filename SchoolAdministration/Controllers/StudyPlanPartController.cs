using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyPlanPartController : ControllerBase
    {
        private readonly IStudyPlanPartRepository _studyPlanPartRepository;

        public StudyPlanPartController(IStudyPlanPartRepository studyPlanPartRepository)
        {
            _studyPlanPartRepository = studyPlanPartRepository;
        }

        [HttpGet("getStudyplanPartsFilter")]
        [ProducesResponseType(typeof(IEnumerable<StudyPlanPart>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task <ActionResult<IEnumerable<StudyPlanPart>>> GetStudyPlanPartsFilter()//DateTime startDate
        {
            var startDate1 = new DateTime(2025, 4, 13);
            var allStudyPlanParts = await _studyPlanPartRepository.GetStudyPlanPartFilterAsync(startDate1);
            return Ok(allStudyPlanParts);
        }

        //[HttpGet("getStudyplanPartsFilter/{startDate}")]
        //[ProducesResponseType(typeof(IEnumerable<StudyPlanPart>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<IEnumerable<StudyPlanPart>>> GetStudyPlanPartsFilter(DateTime startDate)//DateTime startDate
        //{
        //    var startDate1 = new DateTime(2025, 4, 13);
        //    var allStudyPlanParts = await _studyPlanPartRepository.GetStudyPlanPartFilterAsync(startDate1);
        //    return Ok(allStudyPlanParts);
        //}



        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<StudyPlanPart>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudyPlanPart>>> GetAllStudyPlanParts()
        {
            var allStudyPlanParts = await _studyPlanPartRepository.GetAllAsync();
            return Ok(allStudyPlanParts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudyPlanPart), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudyPlanPart>> GetStudyPlanPartById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var studyPlanPart = await _studyPlanPartRepository.GetByIdAsync(id);

            if (studyPlanPart == null)
            {
                return NotFound();
            }

            return Ok(studyPlanPart);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudyPlanPart>> CreateStudyPlanPart(StudyPlanPart studyPlanPart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //if (_studyPlanPartRepository.(studyPlanPart)) // Todo
            //{
            //    ModelState.AddModelError("CustomError", "StudyPlanPart already Exists!");
            //    return BadRequest(ModelState);
            //}

            await _studyPlanPartRepository.AddStudyPlanPartAsync(studyPlanPart);
            return CreatedAtAction(nameof(GetStudyPlanPartById), new { id = studyPlanPart.Id }, studyPlanPart);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteStudyPlanPartById(int id)
        {
            await _studyPlanPartRepository.DeleteStudyPlanPartAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Student>> UpdateStudyPlanPartAsync(int id, StudyPlanPart studyPlanPart)
        {
            if (id != studyPlanPart.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _studyPlanPartRepository.UpdateStudyPlanPartAsync(studyPlanPart);
            return CreatedAtAction(nameof(GetStudyPlanPartById), new { id = studyPlanPart.Id }, studyPlanPart);
        }

    }
}
