namespace SchoolAdministration.Models.DTO
{
    public class UserDTO
    {
        public required string Id { get; set; } //changed from int to string, must contain not a integer, but a Guid
        public  string? UserName { get; set; }
        public string Name { get; set; }
        public  string? Email { get; set; }
        public  string? role { get; set; } // todo : make a list of roles, but for now we assume 1 role per user
    }
}
