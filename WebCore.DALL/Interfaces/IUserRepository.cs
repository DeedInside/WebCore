using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Domain.Models;

namespace WebCore.DALL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// return record from a table by name 
        /// </summary>
        /// <param name="Name">name users</param>
        /// <returns> record type users</returns>
        Task<User> GetName(string Name);
        /// <summary>
        /// returns user data upon successful authorization
        /// </summary>
        /// <param name="name"> name user</param>
        /// <param name="password"> password user</param>
        /// <returns></returns>
        Task<User> GetUserOnLogin(string name, string password);
        /// <summary>
        /// return role users by id
        /// </summary>
        /// <param name="name"> name user </param>
        /// <returns></returns>
        Task<Role> GetUserRole(string name);

    }
}
