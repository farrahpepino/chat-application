using server.Models;
using server.Dtos;

namespace server.Services {
    public interface IChatService {
        Task CreateChatRoom (ChatRoom room);
        Task SendMessage (Message message);
        Task<string> GetChatRoomId(string participantId1, string participantId2);
        Task<IEnumerable<ChatListDto>> GetChatList(string userId);
        Task<IEnumerable<Message>> GetMessages(string chatRoomId);
    }
}