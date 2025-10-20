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
            _context.Chatrooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task SendMessage(Message message){
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetChatRoomId(string participantId1, string participantId2){

           var chatRooms = await _context.Chatrooms.ToListAsync();
            var room = chatRooms.FirstOrDefault(c =>
                c.Participants.Contains(participantId1) &&
                c.Participants.Contains(participantId2));

            return room?.Id.ToString();
        }

        public async Task<IEnumerable<ChatListDto>> GetChatList(string userId){
            var chatrooms = await _context.Chatrooms
                .AsNoTracking()
                .ToListAsync();

            var userChatrooms = chatrooms
                .Where(c => c.Participants.Contains(userId))
                .ToList();

            var result = new List<ChatListDto>();

            foreach (var c in userChatrooms)
            {
                var recipientId = c.Participants.FirstOrDefault(p => p != userId);
                if (recipientId == null) continue;

                var recipient = await _context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == recipientId);

                var latestMessage = await _context.Messages
                    .AsNoTracking()
                    .Where(m => m.ChatRoomId == c.Id)
                    .OrderByDescending(m => m.CreatedAt)
                    .FirstOrDefaultAsync();

                result.Add(new ChatListDto
                {
                    ChatRoomId = c.Id,
                    RecipientId = recipient?.Id ?? "(Unknown)",
                    RecipientName = recipient?.Name ?? "(Unknown)",
                    RecipientUsername = recipient?.Username ?? "(Unknown)",
                    LatestMessage = latestMessage?.Content ?? "",
                    LatestMessageTimestamp = latestMessage?.CreatedAt
                });
            }

            return result
                .OrderByDescending(c => c.LatestMessageTimestamp)
                .ToList();
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