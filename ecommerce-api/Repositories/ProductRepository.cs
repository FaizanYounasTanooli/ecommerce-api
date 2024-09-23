using ecommerce_api.Models;
using ecommerce_api.Services;

namespace ecommerce_api.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(EcommeranceContext context, UserService userService) : base(context, userService)
        {
        }
    }
}
