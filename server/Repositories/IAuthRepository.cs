using server.Models;
using server.Dtos;

namespace server.Repositories{
    public interface IAuthRepository{
        Task<User>  RegisterUser (User user);
        Task<User>  LoginUser (LoginDto user);
    }
}