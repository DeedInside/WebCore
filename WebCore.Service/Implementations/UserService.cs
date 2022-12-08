using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        
        public async Task<bool> AddUser(User user, string filePath, IFormFile uploadedFile)
        {
            User userAdd = new User()
            {
                Name = user.Name,
                Password = user.Password,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            if (uploadedFile == null)
            {
                userAdd.ImageUrl = "/image/Undefine.jpeg";
            }
            else
            {
                userAdd.ImageUrl = "/image/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(filePath + "/wwwroot/" + userAdd.ImageUrl, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
            }
            if (userAdd.Age == null)
            {
                userAdd.Age = DateTime.Now;
            }

            Role userRole = await _userRepository.GetUserRole("User");

            userAdd.Role = userRole;

            
            return await _userRepository.Create(userAdd);
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
