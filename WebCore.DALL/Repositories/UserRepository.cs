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
        /// <summary>
        /// todo: Delits user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// returns list user 
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAll()
        {
            return await _context.UserSQL.ToListAsync();
        }
        /// <summary>
        /// returns record user by name 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
        /// <summary>
        /// todo: returns record user by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public User GetRecord(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// return record from a table by name 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> GetUserOnLogin(string name, string password)
        {

            return await _context.UserSQL.Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Name == name && u.Password == password);
        }
        /// <summary>
        /// returns user data upon successful authorization
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public async Task<bool> Create(User Entity)
        {
            if (Entity != null)
            {
                _context.UserSQL.AddAsync(Entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// return role users by id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Role> GetUserRole(string name)
        {
            Role userRole = await _context.RoleSQL.FirstOrDefaultAsync(n => n.Name == name);
            if(userRole != null)
            {
                return userRole;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
