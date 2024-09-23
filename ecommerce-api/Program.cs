
using ecommerce_api.Extensions;
using ecommerce_api.Models;
using ecommerce_api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api
{
    public class Program
    {
        public  static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<EcommeranceContext>();
            //I wrote extensions to add Services by group and clean up the Main code

            //Extension
            builder.Services.AddRepositories();
            //Extension
            builder.Services.AddIdentityFramework();
            //Extension
            builder.Services.AddServices();
            builder.Services.AddFacades();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<EcommeranceContext>(options =>
                        options.UseMySQL("Server=localhost;Database=ecommerce_api;Uid=root;Pwd=L-v11wK8XyIadp4g;", migrations => migrations.MigrationsAssembly("ecommerce_api")));

            var app = builder.Build();
            //Extension
            app.Services.SeedDatabase();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        
    }
}
