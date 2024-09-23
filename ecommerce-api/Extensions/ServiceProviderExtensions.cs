using ecommerce_api.Models;
using ecommerce_api.Services;
using Microsoft.AspNetCore.Identity;

namespace ecommerce_api.Extensions
{
    public static class ServiceProviderExtensions
    {

        public async static Task SeedDatabase(this IServiceProvider serviceProvider) {
            var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await SeedingService.SeedRoles(userManager, roleManager);
        }
    }
}
