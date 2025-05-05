using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Repositories.Repos;

namespace SchoolAdministration.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        protected ApiResponse _apiResponse;

        public UserController(IUserRepository userRepo)
        {
            _userRepository = userRepo;
            this._apiResponse = new ApiResponse();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var allUsers = await _userRepository.GetAllAsync();
            var userDTOList = new List<UserDTO>();
            foreach (var user in allUsers) 
            {
                userDTOList.Add(new UserDTO
                    {
                        Id = user.Id,
                        Name = user.Name,
                        UserName = user.UserName,
                        Email = user.Email
                    });
            }
            return Ok(userDTOList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> GetUserById(string id)
        {
            if (id == "")
            {
               return BadRequest();
            }

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UserDTO { 
                Id = user.Id ,
                Name = user.Name,
                UserName = user.UserName   
            };

            return Ok(userDTO);
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model) // correct login : username: maddy@test.be   password: Admin123+
        {
            var LoginResponse = await _userRepository.Login(model);
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
            bool ifUserNamUnique = _userRepository.IsUniqueUser(model.UserName);
            if (!ifUserNamUnique)
            {
                _apiResponse.Statuscode = System.Net.HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("Username already exists");
                return BadRequest(_apiResponse);
            }

            var user = await _userRepository.Register(model);
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
