using Core.Security.Jwt;
using Core.Security.Jwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;

namespace Academy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthService _jwtAuthService;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(IJwtAuthService jwtAuthService, UserManager<AppUser> userManager)
        {
            _jwtAuthService = jwtAuthService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var existUser = await _userManager.FindByNameAsync(username);

            if (existUser == null) return BadRequest();

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(existUser, password);

            if (!passwordIsCorrect) return BadRequest();

            var roles = (await _userManager.GetRolesAsync(existUser)).ToList();
            var requestModel = new JwtTokenRequestModel
            {
                Username = username,
                Password = password,
                Roles = roles,
                Email = existUser.Email!
            };

            var tokenResponseModel = await _jwtAuthService.CreateToken(requestModel);

            return Ok(tokenResponseModel);
        }
    }
}