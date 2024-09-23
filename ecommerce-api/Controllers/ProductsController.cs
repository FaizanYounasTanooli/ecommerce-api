using ecommerce_api.DTO;
using ecommerce_api.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcommeranceFacade _ecommerceFacade;
        public ProductsController(EcommeranceFacade ecommeranceFacade)
        {
            _ecommerceFacade = ecommeranceFacade;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto addCategoryDto)
        {
            await _ecommerceFacade.AddProduct(addCategoryDto);
            return Ok("Product Added");
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> AllProducts(AddProductDto addCategoryDto)
        {
            var Products =  await _ecommerceFacade.ListProducts();
            return Ok(Products);
        }
    }
}
