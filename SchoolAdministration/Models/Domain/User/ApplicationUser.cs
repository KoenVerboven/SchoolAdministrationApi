using Microsoft.AspNetCore.Identity;

namespace SchoolAdministration.Models.Domain.User
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
