using Microsoft.AspNetCore.Http;
using WebCore.Domain.Models;
using WebCore.Domain.Response;

namespace WebCore.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<IEnumerable<User>>> GetUsers();
        Task<BaseResponse<User>> GetOneUser(string name, string password);
        Task<User> GetUserToName(string name);
        Task<bool> AddUser(User user, string filePath, IFormFile uploadedFile);
    }
}
