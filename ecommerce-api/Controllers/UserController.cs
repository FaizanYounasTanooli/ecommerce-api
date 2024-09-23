using ecommerce_api.DTO;
using ecommerce_api.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserFacade _useFacade;
        public UserController(UserFacade userFacade)
        {
            _useFacade = userFacade;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto registerUserDto)
        {
            return Ok(await _useFacade.Register(registerUserDto));
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> SignIn(string userName,string password)
        {
            return Ok(await _useFacade.SignIn(userName,password));
        }

    }
}
