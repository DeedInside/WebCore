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
        bool Create(T Entity);
        T GetRecord(int id);
        Task<List<T>> GetAll();
        bool Delete(int id);
    }
}
