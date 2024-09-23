using ecommerce_api.Models;
using Microsoft.AspNetCore.Identity;

namespace ecommerce_api.Services
{
    public static  class SeedingService
    {
        public static  async Task SeedRoles(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            
            var user = new User { UserName = "admin@admin.com", Email = "admin@admin.com" };
            var result = await userManager.CreateAsync(user, "admin");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
            }

            // To assign Admin role
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
