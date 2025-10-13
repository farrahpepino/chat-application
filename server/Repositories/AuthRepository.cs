using server.Dtos;
using server.Models;
using server.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace server.Repositories{
    public class AuthRepository: IAuthRepository{
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context){
            _context = context;
        }
        
        public async Task<User> RegisterUser (User user){

            var existingUser = await (from u in _context.Users
                            where u.Email == user.Email
                            select u).FirstOrDefaultAsync();

            if (existingUser != null){
                return null;
            }

            _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            
        }

        public async Task<UserDto> LoginUser (LoginDto user){

            var existingUser = await (from u in _context.Users
                            where u.Email == user.Email
                            select u).FirstOrDefaultAsync();

            if (existingUser != null && existingUser.Password == user.Password){
                return new UserDto{
                                Id = existingUser.Id,
                                Name = existingUser.Name,
                                Username = existingUser.Username,
                                Email = existingUser.Email,
                                CreatedAt = existingUser.CreatedAt
                            };
            }
            return null;
        }
    }
}