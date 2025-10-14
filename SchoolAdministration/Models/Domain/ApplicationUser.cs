using Microsoft.AspNetCore.Identity;

namespace SchoolAdministration.Models.Domain
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
