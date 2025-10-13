using server.Models;
using server.Dtos;

namespace server.Repositories{
    public interface IAuthRepository{
        Task<User>  RegisterUser (User user);
        Task<UserDto>  LoginUser (LoginDto user);
    }
}