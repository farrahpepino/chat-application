using server.Data;
using System.Threading.Tasks;
using server.Dtos;
using Microsoft.EntityFrameworkCore;

namespace server.Repositories{
    public class UserRepository: IUserRepository{
        private readonly AppDbContext _context;
        

        public UserRepository(AppDbContext context){
            _context = context;
        }

        public async Task<UserDto> GetUser(string userId){
            var user = await (from u in _context.Users 
                        where u.Id == userId
                        select new UserDto{
                            Id = u.Id,
                            Name = u.Name,
                            Username = u.Username,
                            Email =  u.Email,
                            CreatedAt = u.CreatedAt
                        }).FirstOrDefaultAsync();
            return user;
        }

        public async Task<IEnumerable<UserDto>> SearchUser(string query){
            var user = await(from u in _context.Users
                            where u.Name.Contains(query)
                            select new UserDto{
                            Id = u.Id,
                            Name = u.Name,
                            Username = u.Username,
                            Email =  u.Email,
                            CreatedAt = u.CreatedAt
                            }).ToListAsync(); 

            return user;
        }

        public async Task DeleteUser(string userId){
            var user = await (from u in _context.Users
                            where u.Id == userId
                            select u).FirstOrDefaultAsync();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

    }
}