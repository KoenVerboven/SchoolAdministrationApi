namespace SchoolAdministration.Models.Dtos
{
    public class LoginResponseDTO
    {
        public required string Id { get; set; } //changed from int to string, must contain not a integer, but a Guid
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
