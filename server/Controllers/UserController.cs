using server.Services;
using server.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase {
        private readonly IUserService _service;
        public UserController (IUserService service){
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId){

            var user = await _service.GetUser(userId);
            if(user==null){
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("search/{query}")]
        public async Task<IActionResult> SearchUser(string query){

            var user = await _service.SearchUser(query);
            if(user==null){
                return NotFound();
            }
            return Ok(user);
        }
    }
}