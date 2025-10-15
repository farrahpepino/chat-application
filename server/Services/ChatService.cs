using server.Repositories;
using server.Models;
using server.Dtos;
using server.Hubs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace server.Services {
    public class ChatService: IChatService {
        private readonly IChatRepository _repository;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatService(IChatRepository repository, IHubContext<ChatHub> hubContext){
            _repository = repository;
            _hubContext = hubContext;
        }
        
        public async Task CreateChatRoom (ChatRoom room){
            await _repository.CreateChatRoom(room);
        }

        public async Task SendMessage (Message message){
            await _repository.SendMessage(message);
            await _hubContext.Clients.Group(message.ChatRoomId)
                                     .SendAsync("ReceiveMessage", message.SenderId, message.Content);

            var connectionId = ChatHub.GetConnectionId(message.RecipientId);
            if (connectionId != null)
            {
                await _hubContext.Groups.AddToGroupAsync(connectionId, message.ChatRoomId);
                await _hubContext.Clients.Client(connectionId)
                    .SendAsync("JoinedRoom", message.ChatRoomId);
            }
        }

        public async Task<string> GetChatRoomId(ChatRoomDto room){
            return await _repository.GetChatRoomId(room);
        }

        public async Task<IEnumerable<ChatListDto>> GetChatList(string userId){
            return await _repository.GetChatList(userId);
        }

        public async Task<IEnumerable<Message>> GetMessages(string chatRoomId){
            return await _repository.GetMessages(chatRoomId);
        }
    }
}