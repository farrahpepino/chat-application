namespace server.Services{
    public interface IJwtService{
        string GenerateToken(string email);
    }
}