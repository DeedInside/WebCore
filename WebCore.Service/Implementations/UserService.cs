using WebCore.DALL.Interfaces;
using WebCore.Domain.Models;
using WebCore.Domain.Response;
using WebCore.Service.Interfaces;

namespace WebCore.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<User>> GetOneUser(string name, string password)
        {
            var baseResponse = new BaseResponse<User>();
            var user = await _userRepository.GetUserOnLogin(name, password);

            baseResponse.Data = user;
            baseResponse.Description = "Всё чики пуки";
            return baseResponse;
        }

        public async Task<BaseResponse<IEnumerable<User>>> GetUsers()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();
            var users = await _userRepository.GetAll();

            if (users.Count > 0)
            {
                baseResponse.Data = users;
                baseResponse.Description = "Выгрузка прошла успешно";
                return baseResponse;
            }
            else
            {
                baseResponse.Description = "Всё пошло по пиздец, переделывай";
            }
            
            return baseResponse;
        }

        public Task<User> GetUserToName(string name)
        {
            
            if (name != null)
            {
                var ret = _userRepository.GetName(name);
                return ret;
            }
            throw new NotImplementedException();
        }
    }
}
