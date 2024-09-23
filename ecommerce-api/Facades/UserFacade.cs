using ecommerce_api.DTO;
using ecommerce_api.Models;
using ecommerce_api.Repositories;
using ecommerce_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ecommerce_api.Facades
{
    public class UserFacade (SignInManager<User> signInManager, UserManager<User> userManager,UserService userService,CartRepository cartRepository)
    {
        private readonly SignInManager<User> _signInManager = signInManager;
        private readonly UserService _userService = userService;
        private readonly UserManager<User> _userManager = userManager;
        private readonly CartRepository _cartRepository = cartRepository;
        
        public async Task<string> SignIn(string userName,string Password)
        {
            var Result = await _signInManager.PasswordSignInAsync(userName, Password,true,false);
            if (Result.Succeeded) {

                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    
                    _userService.LoggedInUser = user;
                    var userCart = _cartRepository.UsersFirst();
                    if (userCart != null) {
                        _userService.userCart = userCart;
                    }
                    else
                    {
                        var cart = new Cart();
                        _cartRepository.Add(cart);
                        _userService.userCart = cart;
                    }
                    var userForService = new UserDto()
                    {
                        Id = user.Id,
                        Name = user.UserName,
                        Email = user.Email,

                    };

                    return await GenerateToken(user);
                }
                else
                {
                    throw new Exception("User Not logged in properly");
                }

            }
            else {
                throw new Exception("Unable to login user");
            }


        }
        
        public async Task<User> Register(UserRegisterDto registerUserDto)
        {
            var user = new User { UserName = registerUserDto.Email, Email = registerUserDto.Email };
            var result = await _userManager.CreateAsync(user, registerUserDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return user;
            }
            else
            {
                throw new Exception( String.Join(", ",result.Errors.Select(item=>item.Description)));
            }
        }

        async Task<string> GenerateToken(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault() ?? "User"; // Assign a default role if necessary

            // Create claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(ClaimTypes.Role, role)
            };

                    // Generate JWT token
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdfASD123!@#1111111122222313135"));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "testdomain.com",
                        audience: "testdomain.com",
                        claims: claims,
                        expires: DateTime.Now.AddHours(30),
                        signingCredentials: creds);

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }


}
