using server.Models;
using server.Dtos;

namespace server.Repositories{
    public interface IAuthRepository{
        Task<UserDto>  RegisterUser (User user);
        Task<UserDto>  LoginUser (LoginDto user);
    }
}