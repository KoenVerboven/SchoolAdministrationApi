using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain.User;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolAdministration.Repositories.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly string secretKey;

        public UserRepository
            (
                  AppDbContext context,
                  IConfiguration configuration,
                  UserManager<ApplicationUser> userManager,
                  IMapper mapper
            )
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            secretKey = configuration.GetValue<string>("ApiSettings:SecretKey");
        }

        public Task<bool> AddToRoleAsync(string userId, string roleName)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(x => x.Id == userId) ?? throw new InvalidOperationException("User not found");
            var role = _context.Roles.FirstOrDefault(x => x.Name == roleName)?? throw new InvalidOperationException("Role not found");

           
            throw new NotImplementedException();//todo implement this method
        }

        public Task<int> CountAsync()
        {
            return _context.Users.CountAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
           return await _context.ApplicationUsers.ToListAsync();
        }

        public async Task<UserDTO?> GetByIdAsync(string id)
        {
            var user = await _context.ApplicationUsers.FindAsync(id);
            var roles = await _userManager.GetRolesAsync(user);//we gaan er hier van uit : 1 role per user 
            var role = "";
            if (roles != null) { role = roles[0]; };
            var userDTO = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Email = user.Email,
                role = role
            };
            return userDTO;
        }

        public bool IsInRole(string userId, string roleName)
        {
            var user = from s in _context.ApplicationUsers join r in _context.UserRoles on s.Id equals r.UserId
                       where s.Id == userId && r.RoleId == roleName
                       select s;

            if(user != null)
            {
                return true;
            }

            return false;
        }

        public bool IsUniqueUser(string username)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(x => x.UserName == username);

            if (user != null)
            {
                return true;
            }

            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(
                u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower() || u.Email.ToLower() == loginRequestDTO.UserName.ToLower()
            );

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDTO()
                {
                    Id = "",
                    UserName = "",
                    Name= "",
                    Email = "",
                    Role = "",
                    Token = ""
                };
            }

            //if user was found generate JWT Token
            var roles = await _userManager.GetRolesAsync(user);//we gaan er hier van uit : 1 role per user
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    [
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Role,roles.FirstOrDefault())
                    ]
                ),
                Expires = DateTime.UtcNow.AddDays(1000),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new()
            {
                Token = tokenHandler.WriteToken(token),
                //User = _mapper.Map<UserDTO>(user),
                Id = user.Id,
                UserName= user.Name,
                Name= user.Name,
                Email= user.Email,
                Role = roles.FirstOrDefault(),
                //todo Token ????
            };
            return loginResponseDTO;
        }

        //todo :
        // check if the user already exists
        // check if the role is valid 
        // check if the password complies with the policy 
        // check if the email-address is already in use
        // use transaction to ensure data integrity

        public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDTO.UserName,
                LastName = registrationRequestDTO.LastName,
                FirstName = registrationRequestDTO.FirstName,
                DateOfBirth = registrationRequestDTO.DateOfBirth,
                Email = registrationRequestDTO.Email,
                NormalizedEmail = registrationRequestDTO.Email.ToUpper(),
                Name = registrationRequestDTO.Name,
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, registrationRequestDTO.Role);
                    var userToReturn = _context.ApplicationUsers
                        .FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName);
                    return _mapper.Map<UserDTO>(userToReturn); 
                }
            }
            catch (Exception)
            {
                throw;
            }

            return new UserDTO { Id = string.Empty };
        }
    }
}
