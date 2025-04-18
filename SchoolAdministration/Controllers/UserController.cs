using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/UserAuth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        protected ApiResponse _apiResponse;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            this._apiResponse = new ApiResponse();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var LoginResponse = await _userRepo.Login(model);
            if (LoginResponse.User == null || string.IsNullOrEmpty(LoginResponse.Token))
            {
                _apiResponse.Statuscode = System.Net.HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_apiResponse);
            }
            _apiResponse.Statuscode = System.Net.HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result = LoginResponse;
            return Ok(_apiResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            bool ifUserNamUnique = _userRepo.IsUniqueUser(model.UserName);
            if (!ifUserNamUnique)
            {
                _apiResponse.Statuscode = System.Net.HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("Username already exists");
                return BadRequest(_apiResponse);
            }

            var user = await _userRepo.Register(model);
            if (user == null)
            {
                _apiResponse.Statuscode = System.Net.HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("Error while registering");
                return BadRequest(_apiResponse);
            }

            _apiResponse.Statuscode = System.Net.HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            return Ok(_apiResponse);
        }
    }
}
