namespace server.Dtos{
    public class ChatListDto{
        public string ChatRoomId {get; set;}
        public string ParticipantId2 {get; set;}
        public string ParticipantName2 {get; set;}
        public string LatestMessage {get; set;}
        public DateTime LatestMessageTimestamp { get; set; } 
    }
}