using server.Models;
using server.Dtos;

namespace server.Services {
    public interface IChatService {
        Task CreateChatRoom (ChatRoom room);
        Task SendMessage (Message message);
        Task<string> GetChatRoomId(ChatRoomDto room);
    }
}