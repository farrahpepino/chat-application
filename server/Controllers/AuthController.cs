using server.Services;
using server.Models;
using server.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase {
        private readonly IAuthService _service;
        public AuthController (IAuthService service){
            _service = service;
        }
    
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto user){
            var existingUser = await _service.LoginUser(user);
            if (existingUser==null){
                return NotFound();
            }
            return Ok(existingUser);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user){
            var newUser = await _service.RegisterUser(user);
            if (newUser==null){
                return NotFound();
            }
            return Ok(newUser);
        }
    }
}