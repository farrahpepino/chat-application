using server.Dtos;

namespace server.Repositories{
    public interface IUserRepository{
        Task<UserDto> GetUser(string userId);
        Task<IEnumerable<UserDto>> SearchUser(string query);
        Task DeleteUser(string userId);
    }
}