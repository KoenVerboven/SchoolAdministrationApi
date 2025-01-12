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
        public async Task<ActionResult<IEnumerable<StudyPlan>>> GetAllStudyPlans()
        {
            var allStudyPlans = await _studyPlanRepository.GetAllAsync();
            return Ok(allStudyPlans);
        }
        
    }
}
