using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models;
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
        [ProducesResponseType(typeof(IEnumerable<Course>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudyPlan>>> GetAllStudyPlans()
        {
            var allStudyPlans = await _studyPlanRepository.GetAllAsync();
            return Ok(allStudyPlans);
        }





        
    }
}
