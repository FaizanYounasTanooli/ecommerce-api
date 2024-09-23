using ecommerce_api.DTO;
using ecommerce_api.Models;
using ecommerce_api.Repositories;
using PosCommon.Services.Interfaces;

namespace ecommerce_api.Services
{
    public class CartService(UserService userService,CartRepository cartRepository,
        CartItemRepository cartItemRepository,
        ProductRepository productRepository,
        EcommeranceContext ecommeranceContext

        )
    {
        private readonly UserService _userService = userService;
        private readonly CartRepository _cartRepository = cartRepository;
        private readonly ProductRepository _productRepository = productRepository;
        private readonly CartItemRepository _cartItemRepository = cartItemRepository;
        private readonly EcommeranceContext _commeranceContext = ecommeranceContext;
        public void Reload()
        {
            var Cart = _cartRepository.UsersFirst();
            Cart.Items.ToList();
            _userService.userCart = Cart;
        }
        public async Task<bool> AddProductToCart(AddProductToCartDto addProductToCartDto)
        {
            var product = _productRepository.First(prod => prod.Id == addProductToCartDto.ProductId);
            var cartItem = new CartItem
            {
                ProductId = addProductToCartDto.ProductId,
                Quantity = addProductToCartDto.Quantity,
            };
            _cartItemRepository.Add(cartItem);
            var rowsEffected = await _commeranceContext.SaveChangesAsync();
            if (rowsEffected > 0)
            {
                _userService.userCart.Items.Add(cartItem);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteItem(Guid itemId)
        {
            _cartItemRepository.DeleteById(itemId);
            await _commeranceContext.SaveChangesAsync();
            var ItemToRemove = _userService.userCart.Items.First(cartItem => cartItem.Id == itemId);
            if (ItemToRemove != null) {
                _userService.userCart.Items.Remove(ItemToRemove);
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
