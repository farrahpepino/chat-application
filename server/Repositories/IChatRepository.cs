using server.Models;
using server.Dtos;

namespace server.Repositories{
    public interface IChatRepository{
        Task CreateChatRoom (ChatRoom room);
        Task SendMessage (Message message);
        Task<string> GetChatRoomId(ChatRoomDto room);
        Task<IEnumerable<ChatListDto>> GetChatList(string userId);
        Task<IEnumerable<Message>> GetMessages(string chatRoomId);
    }
}