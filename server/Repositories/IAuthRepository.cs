using server.Models;
using server.Dtos;

namespace server.Repositories{
    public interface IAuthRepository{
        Task RegisterUser (User user);
        Task LoginUser (LoginDto user);
    }
}