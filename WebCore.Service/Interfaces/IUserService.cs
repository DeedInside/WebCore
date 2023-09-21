using Microsoft.AspNetCore.Http;
using WebCore.Domain.Models;
using WebCore.Domain.Response;

namespace WebCore.Service.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// returns list user from BD
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<IEnumerable<User>>> GetUsers();
        /// <summary>
        /// Returns user from DB by name and passwor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<BaseResponse<User>> GetOneUser(string name, string password);
        /// <summary>
        /// returns user by name from BD
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<User> GetUserToName(string name);
        /// <summary>
        /// adds record of user in BD
        /// </summary>
        /// <param name="user"></param>
        /// <param name="filePath"></param>
        /// <param name="uploadedFile"></param>
        /// <returns></returns>
        Task<bool> AddUser(User user, string filePath, IFormFile uploadedFile);
    }
}
