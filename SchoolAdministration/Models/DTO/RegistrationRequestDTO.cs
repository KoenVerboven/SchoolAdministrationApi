namespace SchoolAdministration.Models.DTO
{
    public class RegistrationRequestDTO
    {
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }   
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
