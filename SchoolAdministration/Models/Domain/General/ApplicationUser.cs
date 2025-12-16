using Microsoft.AspNetCore.Identity;

namespace SchoolAdministration.Models.Domain.General
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
