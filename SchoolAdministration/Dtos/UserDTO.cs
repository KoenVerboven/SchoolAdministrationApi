namespace SchoolAdministration.Dtos
{
    public class UserDTO
    {
        public string Id { get; set; } //changed from int to string, must contain not a integer, but a Guid
        public string UserName { get; set; }
        public string Name { get; set; }
        public  string Email { get; set; }
    }
}
