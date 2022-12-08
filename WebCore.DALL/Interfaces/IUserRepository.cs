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
        Task<User> GetName(string Name);
        Task<User> GetUserOnLogin(string name, string password);
        Task<Role> GetUserRole(string name);
    }
}
