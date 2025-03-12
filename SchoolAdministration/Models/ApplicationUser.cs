using Microsoft.AspNetCore.Identity;

namespace SchoolAdministration.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
