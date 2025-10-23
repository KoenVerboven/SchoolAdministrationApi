using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Repositories.Interfaces;


namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyPlanController : ControllerBase
    {
        private readonly IStudyPlanRepository _studyPlanRepository;
        public StudyPlanController(IStudyPlanRepository studyPlanRepository )
        {
            _studyPlanRepository = studyPlanRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudyPlan>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudyPlan>>> GetAllStudyPlans()
        {
            var allStudyPlans = await _studyPlanRepository.GetAllAsync();
            return Ok(allStudyPlans);
        }

      
        [HttpGet("getStudyPlansByStudentId/{studentId}")]
        [ProducesResponseType(typeof(StudyPlan), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudyPlan>>> GetStudyPlansByStudentId(int studentId)
        {
            if (studentId == 0)
            {
                return BadRequest();
            }

            var studyPlan = await _studyPlanRepository.GetStudyPlansByStudentId(studentId);

            if (studyPlan == null)
            {
                return NotFound();
            }

            return Ok(studyPlan);
        }



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudyPlan), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudyPlan>> GetStudyPlanById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var studyPlan = await _studyPlanRepository.GetByIdAsync(id);

            if (studyPlan == null)
            {
                return NotFound();
            }

            return Ok(studyPlan);
        }

        //todo : get active studyplan for a specifik student (with student id = X)
        //todo: add active true/false to studyplan


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudyPlan>> CreateStudyPlan(StudyPlan studyPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //if (_studyPlanRepository.(studyPlan)) // Todo : check if studyplan already exists
            //{
            //    ModelState.AddModelError("CustomError", "StudyPlan already Exists!");
            //    return BadRequest(ModelState);
            //}

            await _studyPlanRepository.AddStudyPlanAsync(studyPlan);
            return CreatedAtAction(nameof(GetStudyPlanById), new { id = studyPlan.Id }, studyPlan);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteStudyPlanById(int id)
        {
            await _studyPlanRepository.DeleteStudyPlanAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Student>> UpdateStudyPlanAsync(int id, StudyPlan studyPlan)
        {
            if (id != studyPlan.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _studyPlanRepository.UpdateStudyPlanAsync(studyPlan);
            return CreatedAtAction(nameof(GetStudyPlanById), new { id = studyPlan.Id }, studyPlan);
        }
    }
}
