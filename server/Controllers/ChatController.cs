using server.Services;
using server.Models;
using server.Dtos;
using server.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;


namespace server.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase {
        private readonly IChatService _service;
        public ChatController (IChatService service){
            _service = service;
        }

        [HttpPost("rooms")]
        public async Task<IActionResult> CreateChatRoom ([FromBody] ChatRoom room){
            await _service.CreateChatRoom(room);
            return Ok();
        }

        [HttpPost("messages")]
        public async Task<IActionResult> SendMessage ([FromBody] Message message){
            await _service.SendMessage(message);
            var messageJson = JsonSerializer.Serialize(message);
            await ChatWebSocketHandler.SendMessageToUserAsync(message.RecipientId, messageJson);
            await ChatWebSocketHandler.SendMessageToUserAsync(message.SenderId, messageJson);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetChatRoomId([FromQuery] string participantId1, [FromQuery] string participantId2){
            var roomId = await _service.GetChatRoomId(participantId1, participantId2);
            return Ok(new { roomId });
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
            var messagesJson = JsonSerializer.Serialize(messages);
            foreach (var connection in ChatWebSocketHandler.GetConnections()) {
                await ChatWebSocketHandler.SendMessageToUserAsync(connection.Key, messagesJson);
            }
            return Ok(messages);
        }
    }
}