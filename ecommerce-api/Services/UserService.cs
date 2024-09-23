using ecommerce_api.Models;

namespace ecommerce_api.Services
{
    public class UserService 
    {
        public User LoggedInUser { get; set; } 
        public Cart userCart { get; set; }
    }
}
