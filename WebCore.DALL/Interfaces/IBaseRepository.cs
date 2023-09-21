using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.DALL.Interfaces
{
    /// <summary>
    /// Interfaces works Data Base 
    /// </summary>
    /// <typeparam name="T"> Type User</typeparam>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Creating a user and adding to the database 
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        /// 
        Task<bool> Create(T Entity);
        /// <summary>
        /// get record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetRecord(int id);
        /// <summary>
        ///  returns the entire table from the database
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAll();
        /// <summary>
        /// removal users by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(int id);
    }
}
