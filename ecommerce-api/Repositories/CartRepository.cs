using ecommerce_api.Models;
using ecommerce_api.Services;

namespace ecommerce_api.Repositories
{
    public class CartRepository : BaseRepository<Cart>
    {
        public CartRepository(EcommeranceContext context, UserService userService) : base(context, userService)
        {
            
        }
        public void AddItem()
        {

        }
    }
}
