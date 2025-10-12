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
            var chatroom = await (from c in _context.ChatRooms
                            where c.Participants.Contains(room.ParticipantId1) && 
                            c.Participants.Contains(room.ParticipantId2)
                            select c.Id)
                            .FirstOrDefaultAsync();

            return chatroom;
        }

        public async Task<IEnumerable<ChatListDto>> GetChatList(string userId){
            var chats = await (from c in _context.ChatRooms
                       where c.Participants.Contains(userId)
                       let participantId2 = c.Participants
                                              .Where(p => p != userId)
                                              .FirstOrDefault()
                       join u in _context.Users on participantId2 equals u.Id into userGroup
                       let participant2 = userGroup.FirstOrDefault()

                       join m in _context.Messages on c.Id equals m.ChatRoomId into msgs
                       let latestMessage = msgs.OrderByDescending(m => m.CreatedAt).FirstOrDefault()
                        
                       select new ChatListDto
                       {
                           ChatRoomId = c.Id,
                           ParticipantId2 = participantId2,
                           ParticipantName2 = participant2.Name, 
                           LatestMessage = latestMessage.Content,
                           LatestMessageTimestamp = latestMessage.CreatedAt
                       })
                        .OrderByDescending(c => c.LatestMessageTimestamp) 
                        .ToListAsync(); 

            return chats;
        }

        public async Task<IEnumerable<Message>> GetMessages(string chatRoomId){
            var messages = await (from m in _context.Messages 
                            where m.ChatRoomId == chatRoomId
                            orderby m.CreatedAt descending
                            select m)
                             .ToListAsync();
            return messages;
        }

    }
}