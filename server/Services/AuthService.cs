using server.Repositories;
using server.Models;
using server.Dtos;
using System.Threading.Tasks;
namespace server.Services {
    public class AuthService: IAuthService {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository){
            _repository = repository;
        }
        
        public async Task RegisterUser (User user){
            await _repository.RegisterUser(user);
        }

        public async Task LoginUser (LoginDto user){
            await _repository.LoginUser(user);
        }
    }

}