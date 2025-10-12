using server.Services;
using server.Models;
using server.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase {
        private readonly IChatService _service;
        public ChatController (IChatService service){
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChatRoom ([FromBody] ChatRoom room){
            await _service.CreateChatRoom(room);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage ([FromBody] Message message){
            await _service.SendMessage(message);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetChatRoomId ([FromBody] ChatRoomDto room){
            var roomId = await _service.GetChatRoomId(room);
            if(roomId==null){
                return NotFound();
            }
            return Ok(roomId);
        }

        [HttpGet("{userId}/chats")]
        public async Task<IActionResult> GetChatList(string userId){
            var chats = await _service.GetChatList(userId);
            if(chats==null){
                return NotFound();
            }
            return Ok(chats);
        }

        [HttpGet("{chatRoomId}/messages")]
        public async Task<IActionResult> GetMessages(string chatRoomId){
            var messages = await _service.GetMessages(chatRoomId);
            if(messages==null){
                return NotFound();
            }
            return Ok(messages);
        }
    }
}