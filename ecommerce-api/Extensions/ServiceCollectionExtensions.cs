using ecommerce_api.Facades;
using ecommerce_api.Models;
using ecommerce_api.Repositories;
using ecommerce_api.Services;
using Microsoft.AspNetCore.Identity;

namespace ecommerce_api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ProductRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<CartItemRepository>();
            services.AddScoped<CartRepository>();
        }
        public static void AddServices(this IServiceCollection services) {

            services.AddScoped<UserService>();
            services.AddScoped<CartService>();
        }

        public static void AddIdentityFramework(this IServiceCollection services)
        {

            services.AddScoped<UserService>();
            services.AddScoped<CartService>();
            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<EcommeranceContext>()
            .AddDefaultTokenProviders();
        }
    }
}
