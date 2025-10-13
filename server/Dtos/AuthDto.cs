namespace server.Dtos{
    public class AuthDto{
        public string Token { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}