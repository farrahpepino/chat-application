using server.Models;
using server.Dtos;

namespace server.Services {
    public interface IAuthService {
        Task RegisterUser (User user);
        Task LoginUser (LoginDto user);
    }
}