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
        User GetName(string Name);
    }
}
