using Microsoft.AspNetCore.Identity;

namespace ecommerce_api.Models
{
    public class User : IdentityUser
    {

        public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    }
}
