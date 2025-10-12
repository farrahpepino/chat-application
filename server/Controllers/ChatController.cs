using server.Services;
using server.Models;

namespace server.Controllers {
    public class ChatController {
        private readonly IChatService _service;
        public ChatController (IChatService service){
            _service = service;
        }
    }
}