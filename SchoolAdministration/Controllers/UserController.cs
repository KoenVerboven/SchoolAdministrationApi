using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Models.Domain.General;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        protected ApiResponse _apiResponse;

        public UserController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
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

            return Ok(user);
        }


        //todo : add Authorization 
        //https://learn.microsoft.com/en-us/aspnet/core/security/authorization/iauthorizationpolicyprovider?view=aspnetcore-10.0
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model) // correct login : username: maddy@test.be   password: Admin123+    ; Koen Admin123@
        {
            var LoginResponse = await _userRepository.Login(model);
            if (LoginResponse == null || string.IsNullOrEmpty(LoginResponse.Token))
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

        //todo :
        // check if the role is valid 
        // check if the password complies with the policy (min length, uppercase, lowercase, digit, special character)
        // https://stackoverflow.com/questions/39825634/how-override-asp-net-core-identitys-password-policy
        // https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-10.0&tabs=visual-studio

        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationRequestDTO model)
        {
            bool userNameIsUnique = _userRepository.IsUniqueUser(model.UserName);
            
            if (!userNameIsUnique)
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

        [HttpPost("AssignRoleToUserAsync")]
        public async Task AssignRoleToUserAsync(string userId, string roleName) // todo : change roleName in list of roleNames, so we can assign multiple roles to a user in one call
        {
            var user = await _userRepository.GetByIdAsync(userId) ?? throw new Exception("User not found");

            if (!await _roleRepository.RoleExistsAsync(roleName))
            {
                //await _roleRepository.CreateAsync(new IdentityRole(roleName));
                //throw new Exception($"Rol '{roleName}' bestaat niet.");
                //return BadRequest($"Role '{roleName}' does not exist.");
            }

            var isInRole =  _userRepository.IsInRole(userId, roleName);

            if (!isInRole)
            {
                var result = await _userRepository.AddToRoleAsync(userId, roleName);
            }

            //return result;
        }

    }

}


