using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.UserSQL.ToListAsync();
        }

        public async Task<User> GetName(string Name)
        {
            var ret = await _context.UserSQL.FirstOrDefaultAsync( n => n.Name == Name);
            if (ret != null)
            {
                return ret;
            }
            else
                throw new NotImplementedException();
        }

        public User GetRecord(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserOnLogin(string name, string password)
        {

            return await _context.UserSQL.Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Name == name && u.Password == password);

        }

        Task<bool> IBaseRepository<User>.Create(User Entity)
        {
            throw new NotImplementedException();
        }
    }
}
