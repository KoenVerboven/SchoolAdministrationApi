namespace SchoolAdministration.Dtos
{
    public class LoginRequestDTO
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
