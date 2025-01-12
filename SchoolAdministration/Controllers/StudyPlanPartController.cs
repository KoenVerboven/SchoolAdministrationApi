using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models;
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

        [HttpGet]
        public async Task <ActionResult<IEnumerable<StudyPlanPart>>> GetAllStudyPlanParts()
        {
            var allStudyPlanParts = await _studyPlanPartRepository.GetAllAsync();
            return Ok(allStudyPlanParts);
        }

    }
}
