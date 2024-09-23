using ecommerce_api.Models;
using ecommerce_api.Services;

namespace ecommerce_api.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem>
    {
        public CartItemRepository(EcommeranceContext context, UserService userService) : base(context, userService)
        {
        }
    }
}
