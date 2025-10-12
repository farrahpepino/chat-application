using server.Repositories;
using server.Dtos;
using System.Threading.Tasks;

namespace server.Services {
    public class UserService: IUserService {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository){
            _repository = repository;
        }
        
        public async Task<UserDto> GetUser (string userId){
            return await _repository.GetUser(userId);
        }
    }
}