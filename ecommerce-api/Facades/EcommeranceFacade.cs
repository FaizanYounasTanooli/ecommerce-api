using ecommerce_api.DTO;
using ecommerce_api.Models;
using ecommerce_api.Repositories;
using ecommerce_api.Services;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ecommerce_api.Facades
{
    public class EcommeranceFacade(
        UserService userService,
        ProductRepository productRepository,
        EcommeranceContext ecommeranceContext,
        CategoryRepository categoryRepository,
        CartService cartService
        )
    {
        private readonly UserService _userService = userService;
        private readonly CategoryRepository _categoryRepository = categoryRepository;
        private readonly ProductRepository _productRepository = productRepository;
        private readonly EcommeranceContext _commeranceContext = ecommeranceContext;
        private readonly CartService _cartService = cartService;


        public async Task<IEnumerable<Category>> ListCategories()
        {
            return await _categoryRepository.GetAll().ToListAsync();
        }
        public async Task<IEnumerable<Product>> ListProducts()
        {
            return await _productRepository.GetAll().ToListAsync();
        }
        public Cart UserCart()
        {
            return _userService.userCart;
        }
        public async Task<bool> AddProductToCart(AddProductToCartDto addProductToCartDto)
        {
            return await _cartService.AddProductToCart(addProductToCartDto);
        }

        public async Task<bool> DeleteProductFromCart(Guid itemId) {
           return await _cartService.DeleteItem(itemId);
        }
        public async Task<Category> AddCategory(AddCategoryDto addCategoryDto) {
            Category category = new Category()
            {
                Name = addCategoryDto.Name,
            };
            _categoryRepository.Add(category);
            await _commeranceContext.SaveChangesAsync();
            return category;

        }
        public async Task<Product> AddProduct(AddProductDto productDto)
        {
            Product product = productDto.ToModel<Product>();
            _productRepository.Add(product);
            await _commeranceContext.SaveChangesAsync();
            return product;
        }

    }
}
