using AspNetAuthApi.Dtos;
using AspNetAuthApi.Models;
using AspNetAuthApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authService.Register(new User
            { UserName = request.UserName }, request.Password);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authService.Login(request.UserName, request.Password);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}