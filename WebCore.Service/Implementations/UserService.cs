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
    }
}
