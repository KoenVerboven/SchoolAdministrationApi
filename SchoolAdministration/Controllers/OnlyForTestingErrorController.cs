using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain;

namespace SchoolAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlyForTestingErrorController : ControllerBase
    {
        // This endpoints are only for testing error handling.

        [HttpGet("trigger-error")]
        public IActionResult TriggerError()
        {
            throw new System.Exception("This is a test exception for error handling.");
        }

        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized("You are not authorized to access this resource.");
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return Unauthorized("Bad request.");
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            return NotFound();
        }

        [HttpGet("internalerror")]
        public IActionResult GetInternalError()
        {
            throw new Exception("Simulated internal server error.");
        }

        [HttpGet("validationerror")]
        public IActionResult GetValidationError(Course course)
        {
            return Ok();
        }

    }
}
