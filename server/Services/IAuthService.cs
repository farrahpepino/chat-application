using server.Models;
using server.Dtos;

namespace server.Services {
    public interface IAuthService {
        Task<AuthDto> RegisterUser (User user);
        Task<AuthDto> LoginUser (LoginDto user);
    }
}