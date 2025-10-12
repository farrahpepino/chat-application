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
        
        public async Task RegisterUser (User user){
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task LoginUser (LoginDto user){

            var query = from u in _context.Users
                            where u.Email == user.Email
                            select u;

            var existingUser = await query.FirstOrDefaultAsync();

            if (existingUser != null && existingUser.Password == user.Password){
                Console.WriteLine("Login successful!");
            }


        }
    }
}