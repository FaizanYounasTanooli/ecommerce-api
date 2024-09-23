using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Models
{
    public class EcommeranceContext :  IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   //=> optionsBuilder.UseNpgsql("Host=localhost;Database=pos;Username=postgres;Password=L-v11wK8XyIadp4g");
   => optionsBuilder.UseMySQL("Server=localhost;Database=WebPOS;Uid=root;Pwd=L-v11wK8XyIadp4g;");

    }
}
