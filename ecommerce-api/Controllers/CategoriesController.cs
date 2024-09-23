using ecommerce_api.DTO;
using ecommerce_api.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly EcommeranceFacade _ecommerceFacade;
        public CategoriesController(EcommeranceFacade ecommeranceFacade) { 
            _ecommerceFacade = ecommeranceFacade;
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDto addCategoryDto)
        {
            await _ecommerceFacade.AddCategory(addCategoryDto);
            return Ok("Category Added");
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> AllCategories(AddProductDto addCategoryDto)
        {
            var categories = await _ecommerceFacade.ListCategories();
            return Ok(categories);
        }
    }
}
