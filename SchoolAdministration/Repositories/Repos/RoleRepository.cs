using SchoolAdministration.Data;

namespace SchoolAdministration.Repositories.Repos
{
    public class RoleRepository(AppDbContext context) : Interfaces.IRoleRepository
    {
        private readonly AppDbContext _context = context;

        public bool RoleExistsAsync(string name)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Name == name);

            if (role != null)
            {
                return true;
            }

            return false;
        }
    }
}
