using server.Repositories;
using server.Models;
using server.Dtos;
using System.Threading.Tasks;

namespace server.Services {
    public class ChatService: IChatService {
        private readonly IChatRepository _repository;

        public ChatService(IChatRepository repository){
            _repository = repository;
        }
        
        public async Task CreateChatRoom (ChatRoom room){
            await _repository.CreateChatRoom(room);
        }

        public async Task SendMessage (Message message){
            await _repository.SendMessage(message);
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