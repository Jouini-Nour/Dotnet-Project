using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Dotnet_Project.Services
{
    public static class IdentitySeeder
    {
        public static async Task SeedRolesAndAdmin(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string hrAdminEmail = "hradmin@example.com";
            string pmAdminEmail = "pmadmin@example.com";
            string defaultPassword = "Admin@123";

            // Ensure HR Manager role exists
            if (!await roleManager.RoleExistsAsync("HR Manager"))
                await roleManager.CreateAsync(new IdentityRole("HR Manager"));

            // Ensure Project Manager role exists
            if (!await roleManager.RoleExistsAsync("Project Manager"))
                await roleManager.CreateAsync(new IdentityRole("Project Manager"));

            // Create and assign HR Manager admin user
            var hrAdminUser = await userManager.FindByEmailAsync(hrAdminEmail);
            if (hrAdminUser == null)
            {
                hrAdminUser = new IdentityUser { UserName = hrAdminEmail, Email = hrAdminEmail, EmailConfirmed = true };
                await userManager.CreateAsync(hrAdminUser, defaultPassword);
                await userManager.AddToRoleAsync(hrAdminUser, "HR Manager");
            }

            // Create and assign Project Manager admin user
            var pmAdminUser = await userManager.FindByEmailAsync(pmAdminEmail);
            if (pmAdminUser == null)
            {
                pmAdminUser = new IdentityUser { UserName = pmAdminEmail, Email = pmAdminEmail, EmailConfirmed = true };
                await userManager.CreateAsync(pmAdminUser, defaultPassword);
                await userManager.AddToRoleAsync(pmAdminUser, "Project Manager");
            }
        }
    }
}
