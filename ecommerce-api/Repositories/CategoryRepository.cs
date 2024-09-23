using ecommerce_api.Models;
using ecommerce_api.Services;

namespace ecommerce_api.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(EcommeranceContext context, UserService userService) : base(context, userService)
        {
        }
    }
}
