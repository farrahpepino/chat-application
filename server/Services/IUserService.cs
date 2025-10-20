using server.Dtos;

namespace server.Services {
    public interface IUserService {
        Task<UserDto> GetUser(string userId);
        Task<IEnumerable<UserDto>> SearchUser(string query);
        Task DeleteUser(string userId);
    }
}