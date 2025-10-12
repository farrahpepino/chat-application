using server.Dtos;

namespace server.Services {
    public interface IUserService {
        Task<UserDto> GetUser(string userId);
    }
}