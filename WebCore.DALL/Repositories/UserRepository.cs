using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.DALL.Interfaces;
using WebCore.Domain.Models;

namespace WebCore.DALL.Repositories
{
    /// <summary>
    /// Realization IUserRepository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        public bool Create(User Entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetName(string Name)
        {
            throw new NotImplementedException();
        }

        public User GetRecord(int id)
        {
            throw new NotImplementedException();
        }
    }
}
