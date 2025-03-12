namespace SchoolAdministration.Dtos
{
    public class RegistrationRequestDTO
    {
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
