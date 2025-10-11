using server.Services;
using server.Models;

namespace server.Controllers{
    public class AuthController {
        private readonly IAuthService _service;
        public AuthController (IAuthService service){
            _service = service;
        }
    }
}