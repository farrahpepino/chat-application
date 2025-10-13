using BCrypt.Net;
namespace server.Helpers{
    public class PasswordManager{
        public static string HashPassword(string password){
        return BCrypt.Net.BCrypt.HashPassword(password, 13);
        }

        public static bool VerifyPassword(string password, string hashedPassword){
        var verified = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        return verified;
        }
    }
}