using server.Models;
using server.Dtos;
using server.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace server.Repositories{
    public class ChatRepository: IChatRepository{
        private readonly AppDbContext _context;
        

        public ChatRepository(AppDbContext context){
            _context = context;
        }

        public async Task CreateChatRoom (ChatRoom room){
            _context.ChatRooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task SendMessage(Message message){
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetChatRoomId(ChatRoomDto room){
            var chatroom = (from c in _context.ChatRooms
                            where c.Participants.Contains(room.ParticipantId1) && 
                            c.Participants.Contains(room.ParticipantId2)
                            select c.Id)
                            .FirstOrDefault();

            if (chatroom == null){
                return null;
            }

            return chatroom;
        }

    }
}