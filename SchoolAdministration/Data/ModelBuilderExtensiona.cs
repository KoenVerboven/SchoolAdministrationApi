using Microsoft.AspNetCore.Identity;
using SchoolAdministration.Models;

namespace SchoolAdministration.Data
{
    public static class IdentitySeeder
    {
        //goal : seed the AspNetUsers-table with a ADMIN user and the AspNetRoles-table wiht the roles 
        //https://medium.com/@roshanj100/users-and-roles-seeding-in-asp-net-core-identity-with-entity-framework-core-a-step-by-step-guide-28e6f76a18db
        public static async Task  SeedRolesAndAdminAsync()
        {
            var roles = new[] { "Admin", "Teacher", "Student", "Parent" };

            foreach (var role in roles)
            {
                //if (!await roleManager.RoleExistsAsync(role))
                //{
                //    await roleManager.CreateAsync(new ApplicationRole(role));
                //}

                // Define the admin user details
                //var adminEmail = "admin@gmail.com";
                //var adminPassword = "Admin@123";

                // Check if the admin user already exists
                //var userExist = await userManager.FindByEmailAsync(adminEmail);
                //if (userExist == null)
                //{
                //    var adminUser = new ApplicationUser
                //    {
                //        UserName = "admin",
                //        Email = adminEmail,
                //        FullName = "Admin",
                //        PhoneNumber = "071825865",
                //        EmailConfirmed = true
                //    };

                //    // Create the admin user
                //    var result = await userManager.CreateAsync(adminUser, adminPassword);
                //    if (result.Succeeded)
                //    {
                //        // Assign the Admin role to the user
                //        await userManager.AddToRoleAsync(adminUser, "Admin");
                //    }
                //    else
                //    {
                //        throw new Exception("Failed to create the admin user: " + string.Join(", ", result.Errors));
                //    }
                //}
            }
        }
    }
}
