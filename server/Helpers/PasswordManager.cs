using BCrypt.Net;
namespace server.Helpers{
    public class PasswordManager{
        public static string HashPassword(string password){
        return BCrypt.EnhancedHashPassword(password, 13);
        }

        public static bool VerifyPassword(string password, string hashedPassword){
        return BCrypt.EnhancedVerify(password, hashedPassword);
        }
    }
}