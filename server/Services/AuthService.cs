using server.Repositories;
using server.Models;
using server.Dtos;
using System.Threading.Tasks;

namespace server.Services {
    public class AuthService: IAuthService {
        private readonly IAuthRepository _repository;
        private readonly IJwtService _jwtService;


        public AuthService(IAuthRepository repository, IJwtService jwtService){
            _repository = repository;
            _jwtService = jwtService;
        }
        
        public async Task<AuthDto> RegisterUser (User user){
            var newUser = await _repository.RegisterUser(user);
            if (newUser==null){
                return null;
            }

            var token = _jwtService.GenerateToken(user.Email);
            return new AuthDto {
                Token = token,
                Id = newUser.Id,
                Name = newUser.Name,
                Username = newUser.Username,
                Email = newUser.Email,
                CreatedAt = newUser.CreatedAt
            };
        }

        public async Task<AuthDto> LoginUser (LoginDto user){
            var existingUser = await _repository.LoginUser(user);
            if (existingUser==null){
                return null;
            }
            var token = _jwtService.GenerateToken(user.Email);
            return new AuthDto {
                Token = token,
                Id = existingUser.Id,
                Name = existingUser.Name,
                Username = existingUser.Username,
                Email = existingUser.Email,
                CreatedAt = existingUser.CreatedAt
            };
        }
    }

}