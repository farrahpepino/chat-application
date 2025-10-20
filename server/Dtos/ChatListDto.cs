namespace server.Dtos{
    public class ChatListDto{
        public string ChatRoomId {get; set;}
        public string RecipientId {get; set;}
        public string RecipientName {get; set;}
        public string RecipientUsername {get; set;}
        public string LatestMessage {get; set;}
        public DateTime? LatestMessageTimestamp { get; set; } 
    }
}