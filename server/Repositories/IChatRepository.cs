using server.Models;

namespace server.Repositories{
    public interface IChatRepository{
        Task CreateChatRoom (ChatRoom room);
        Task SendMessage (Message message);
        Task<string> GetChatRoomId (string participantId1, string participant2);
    }
}